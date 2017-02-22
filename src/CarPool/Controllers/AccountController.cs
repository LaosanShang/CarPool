using CarPool.Db;
using CarPool.Db.Entities;
using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarPool.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// 账户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            using (CpDbContext db = new CpDbContext())
            {
                var user = db.Users.AsNoTracking().Where(t => t.Phone == User.Identity.Name).SingleOrDefault();
                return View(user == null ? new UserVModel() : user.ToVModel());
            }
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Regist(UserVModel userVm)
        {
            using (CpDbContext db = new CpDbContext())
            {
                if (ModelState.IsValid)
                {
                    //手机号码不能重复
                    var user = db.Users.AsNoTracking().Where(t => t.Phone == userVm.Phone).SingleOrDefault();
                    if (user != null) throw new ApplicationException("该手机号码已注册！");
                    User newUser = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = userVm.Name,
                        Sex = userVm.Sex,
                        Phone = userVm.Phone
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    //自动登录
                    FormsAuthentication.SetAuthCookie(newUser.Phone, true);
                    return ResultSuccess<string>("注册成功！");
                }
                else {
                    return ResultFailure(ModelState.Values.Where(v=>v.Errors.Count > 0).FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
                }
            }
        }
    }
}