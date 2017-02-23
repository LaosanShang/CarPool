using CarPool.Models.Admin.MessageManage;
using CarPool.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPool.Common;
using CarPool.Models;
using CarPool.Db.Entities;
using EntityFramework.Extensions;

namespace CarPool.Controllers
{
    [AllowAnonymous]
    public class MessageManageController : BaseController
    {
        public ActionResult Index()
        {
            return View(new PageDto());
        }
        
        public ContentResult Query(QueryConditionDto dto, Pager pager)
        {
            using (Db.CpDbContext db = new Db.CpDbContext())
            {
                DateTime startStartTime = Convert.ToDateTime(dto.StartTime);
                DateTime endStartTime = Convert.ToDateTime(dto.EndTime).AddDays(1);
                var dtos = new List<MessageVModel>();
                var query = db.Messages.AsNoTracking().AsQueryable();
                if (!string.IsNullOrEmpty(dto.StartName))
                    query = query.Where(t => t.StartName.Contains(dto.StartName));
                if(!string.IsNullOrEmpty(dto.MessageType))
                    query = query.Where(t => t.MessageType == (MessageType)Convert.ToInt32(dto.MessageType));
                query = query.Where(t => t.StartTime > startStartTime).Where(t => t.StartTime < endStartTime);
                query = query.Page(pager);
                query.ToList().ForEach(t => dtos.Add(t.ToVModel()));
                return ResultDataGrid<MessageVModel>(dtos, pager);
            }  
        }

        public ActionResult MessageEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return PartialView("_editForm", new MessageVModel());
            else
            {
                MessageVModel dto = new MessageVModel(); //_userService.GetUser(SafeConvert.ToInt64(id));
                return PartialView("_editForm", dto);
            }
        }
        
        public ContentResult Add(MessageVModel dto)
        {
            //_userService.AddUser(dto);
            return ResultSuccess<string>("添加成功");
        }
        
        public ContentResult Modify(MessageVModel dto)
        {
            //_userService.ModifyUser(dto);
            return ResultSuccess<string>("修改成功");
        }
        
        public ContentResult Remove(long? id)
        {
            //_userService.DeleteUser(new UserDto { Id = id });
            return ResultSuccess<string>("删除成功");
        }

        public ContentResult Top(string id)
        {
            using (Db.CpDbContext db = new Db.CpDbContext())
            {
                db.Messages.Where(t=>t.Id == id).Update(t=>new Message{ IsTop = true});
                db.SaveChanges();
            }
            return ResultSuccess<string>("顶置成功");
        }
    }
}