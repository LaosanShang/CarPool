using CarPool.Models.Admin.UserManage;
using CarPool.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPool.Common;

namespace CarPool.Controllers
{
    [AllowAnonymous]
    public class UserManageController : BaseController
    {
        public ActionResult Index()
        {
            return View(new PageDto());
        }
        
        public ContentResult Query(QueryConditionDto dto, Pager pager)
        {
            using (Db.CpDbContext db = new Db.CpDbContext())
            {
                var dtos = new List<UserDto>();
                var query = db.Users.AsNoTracking().AsQueryable();
                if (!string.IsNullOrEmpty(dto.UserName))
                    query = query.Where(t => t.Name.Contains(dto.UserName));
                query = query.Page(pager);
                query.ToList().ForEach(t=>dtos.Add(new UserDto {
                    UserName = t.Name,
                    Sex = t.Sex,
                    Phone = t.Phone,
                    Id = t.Id
                }));
                return ResultDataGrid<UserDto>(dtos, pager);
            }  
        }

        public ActionResult UserEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return PartialView("_editForm", new UserDto());
            else
            {
                UserDto dto = new UserDto(); //_userService.GetUser(SafeConvert.ToInt64(id));
                return PartialView("_editForm", dto);
            }
        }
        
        public ContentResult Add(UserDto dto)
        {
            //_userService.AddUser(dto);
            return ResultSuccess<string>("添加成功");
        }
        
        public ContentResult Modify(UserDto dto)
        {
            //_userService.ModifyUser(dto);
            return ResultSuccess<string>("修改成功");
        }
        
        public ContentResult Remove(long? id)
        {
            //_userService.DeleteUser(new UserDto { Id = id });
            return ResultSuccess<string>("删除成功");
        }
    }
}