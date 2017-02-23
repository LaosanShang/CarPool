using CarPool.Models.Admin;
using CarPool.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarPool.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        #region 登录
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="loginVm"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult CheckLogin(LoginVModel loginVm)
        {
            using (Db.CpDbContext db = new Db.CpDbContext())
            {
                var manager = db.Managers.AsNoTracking().Where(t => t.UserName == loginVm.UserName).Where(t => t.Password == loginVm.Password).SingleOrDefault();
                if(manager == null) return ResultFailure("用户名或密码错误");
                else
                {
                    FormsAuthentication.SetAuthCookie(manager.UserName, true);
                    return ResultSuccess<string>("登录成功");
                }
            }
        } 
        #endregion

        public ActionResult Index()
        {
            List<MenuDto> menus = new List<MenuDto>
            {
                new MenuDto { Id = "1",Icon = "fa-file",MenuName ="用户管理",Url = "~/UserManage/Index"},
                new MenuDto { Id = "2",Icon = "fa-file",MenuName ="广告管理",Url = "~/AdvertManage/Index"},
                new MenuDto { Id = "3",Icon = "fa-file",MenuName ="发布消息管理",Url = "~/MessageManage/Index"}
            };
            return View(menus);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}