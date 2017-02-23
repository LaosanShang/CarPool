using CarPool.Db;
using CarPool.Db.Entities;
using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EntityFramework.Extensions;
using CarPool.Models.Admin.AdvertManage;

namespace CarPool.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            using (CpDbContext db = new CpDbContext())
            {
                IndexVModel indexVm = new IndexVModel();
                db.Adverts.AsNoTracking().AsQueryable().ToList().ForEach(t => indexVm.Adverts.Add(new AdvertDto { Id = t.Id, Description = t.Description, ImageUrl = t.ImageUrl, Title = t.Title }));
                return View(indexVm);
            }

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckLogin(LoginVModel loginVm)
        {
            using (CpDbContext db = new CpDbContext())
            {
                if (ModelState.IsValid)
                {
                    var user = db.Users.AsNoTracking().Where(t => t.Phone == loginVm.Phone).SingleOrDefault();
                    if (user == null) throw new ApplicationException("用户不存在");
                    FormsAuthentication.SetAuthCookie(user.Phone, true);
                    return ResultSuccess<string>("登录成功");
                }
                return ResultFailure(ModelState.Values.Where(v=>v.Errors.Count > 0).FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }
        }

        public ActionResult Publish()
        {
            return View();
        }

        public ActionResult PublishMessage(MessageVModel msgVm)
        {
            using (CpDbContext db = new CpDbContext())
            {
                if (ModelState.IsValid)
                {
                    Message msg = new Message()
                    {
                        Id = Guid.NewGuid().ToString(),
                        StartTime = Convert.ToDateTime(msgVm.StartTime),
                        Description = msgVm.Description,
                        StartName = msgVm.StartName,
                        EndName = msgVm.EndName,
                        SeatCount = msgVm.SeatCount,
                        Contact = msgVm.Contact,
                        Price = msgVm.Price,
                        MessageType = (MessageType)msgVm.MessageType,
                        Phone = msgVm.Phone
                    };
                    db.Messages.Add(msg);
                    db.SaveChanges();
                    return ResultSuccess<string>("信息发布成功！");
                }
                return ResultFailure(ModelState.Values.Where(v=>v.Errors.Count > 0).FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }
        }
        /// <summary>
        /// 加载票信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">行数</param>
        /// <param name="msgType">消息类型</param>
        /// <returns></returns>
        public ActionResult LoadMessage(int page, int rows, int? msgType,string msg)
        {
            using (CpDbContext db = new CpDbContext())
            {
                List<MessageVModel> msgs = new List<MessageVModel>();
                var query = db.Messages.AsNoTracking().Where(t => t.MessageType == (MessageType)msgType).AsQueryable();
                if (!string.IsNullOrEmpty(msg)) query = query.Where(t=>t.StartName.Contains(msg) || t.EndName.Contains(msg));
                query.OrderByDescending(t => new { t.IsTop, t.StartTime })
                    .Skip((page - 1) * rows)
                    .Take(rows)
                    .ToList()
                    .ForEach(t => msgs.Add(t.ToVModel()));
                return PartialView("~/Views/PartialViews/_messageLi.cshtml", msgs);
            }
        }

        /// <summary>
        /// 信息详情页
        /// </summary>
        /// <param name="id">信息Id</param>
        /// <returns></returns>
        public ActionResult MessageDetail(string id)
        {
            Message msg;
            using (CpDbContext db = new CpDbContext())
            {
                db.Messages.Where(t => t.Id == id).Update(t => new Message { Ticks = t.Ticks + 1 });
                db.SaveChanges();
                msg = db.Messages.Where(t => t.Id == id).FirstOrDefault();
            }
            return View(msg.ToVModel());
        }
    }
}