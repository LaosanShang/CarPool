using CarPool.Models.Admin.AdvertManage;
using CarPool.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPool.Common;
using EntityFramework.Extensions;
using CarPool.Db.Entities;
using System.IO;

namespace CarPool.Controllers
{
    [AllowAnonymous]
    public class AdvertManageController : BaseController
    {
        const string FILE_PATH = "~/FileUpLoad/Adverts/";
        public ActionResult Index()
        {
            return View(new PageDto());
        }
        
        public ContentResult Query(QueryConditionDto dto, Pager pager)
        {
            using (Db.CpDbContext db = new Db.CpDbContext())
            {
                var dtos = new List<AdvertDto>();
                var query = db.Adverts.AsNoTracking().AsQueryable();
                if (!string.IsNullOrEmpty(dto.Title))
                    query = query.Where(t => t.Title.Contains(dto.Title));
                query = query.Page(pager);
                query.ToList().ForEach(t=>dtos.Add(new AdvertDto
                {
                    Title = t.Title,
                    ImageUrl = t.ImageUrl.Trim('~'),
                    Description = t.Description,
                    Id = t.Id
                }));
                return ResultDataGrid<AdvertDto>(dtos, pager);
            }  
        }

        public ActionResult AdvertEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return PartialView("_editForm", new AdvertDto());
            else
            {
                AdvertDto dto = new AdvertDto(); //_AdvertService.GetAdvert(SafeConvert.ToInt64(id));
                return PartialView("_editForm", dto);
            }
        }
        
        public ContentResult Add(AdvertDto dto)
        {
            using (Db.CpDbContext db = new Db.CpDbContext())
            {
                dto.ImageUrl = SaveFile();
                if (string.IsNullOrEmpty(dto.ImageUrl)) throw new ApplicationException("文件上传失败！");
                Advert advert = new Db.Entities.Advert
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = dto.Title,
                    ImageUrl = dto.ImageUrl,
                    Description = dto.Description
                };
                db.Adverts.Add(advert);
                db.SaveChanges();
            }
            return ResultSuccess<string>("添加成功");

        }

        private string SaveFile()
        {
            string info = string.Empty;
            try
            {
                //获取客户端上传的文件集合
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                //判断是否存在文件
                if (files.Count > 0)
                {
                    //获取文件集合中的第一个文件(每次只上传一个文件)
                    HttpPostedFile file = files[0];
                    //定义文件存放的目标路径
                    string targetDir = System.Web.HttpContext.Current.Server.MapPath(FILE_PATH);
                    //创建目标路径
                    Directory.CreateDirectory(targetDir);
                    //组合成文件的完整路径
                    string path = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file.FileName));
                    //保存上传的文件到指定路径中
                    file.SaveAs(path);
                    info =FILE_PATH + file.FileName;
                }
                else 
                    throw new ApplicationException("请选择文件");
            }
            catch
            {
                info = "";
            }
            return info;
        }

        public ContentResult Modify(AdvertDto dto)
        {
            
            return ResultSuccess<string>("修改成功");
        }
        
        public ContentResult Remove(string id)
        {
            using (Db.CpDbContext db = new Db.CpDbContext())
            {
                db.Adverts.Where(t => t.Id == id).Delete();
                db.SaveChanges();
            }
            return ResultSuccess<string>("删除成功");
        }
    }
}