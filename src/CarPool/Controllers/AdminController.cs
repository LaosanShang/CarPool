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
    public class AdminController : BaseController
    {
        #region 登录
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckLogin(LoginVModel loginVm)
        {
            if(loginVm.UserName == "admin" && loginVm.Password == "123")
            {
                return ResultSuccess<string>("登录成功");
            }
            else
                return ResultFailure("用户名或密码错误");
        } 
        #endregion

        public ActionResult Index()
        {
            List<MenuDto> menus = new List<MenuDto>
            {
                new MenuDto { Id = "1",Icon = "fa-file",MenuName ="用户管理",Url = "~/UserManage/Index"},
                new MenuDto { Id = "2",Icon = "fa-file",MenuName ="发布消息管理",Url = "~/MessageManage/Index"}
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