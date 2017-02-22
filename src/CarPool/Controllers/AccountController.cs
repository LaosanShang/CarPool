using CarPool.Db;
using CarPool.Db.Entities;
using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarPool.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
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
                //手机号码不能重复
                var user = db.Users.AsNoTracking().Where(t => t.Phone == userVm.Phone).SingleOrDefault();
                if (user != null) return RedirectToAction("Register", userVm);
                User newUser = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = userVm.Name,
                    Sex = userVm.Sex,
                    Phone = userVm.Phone
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}