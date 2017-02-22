using CarPool.Models;
using CarPool.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarPool.Controllers
{
    public abstract class BaseController : Controller
    {

        #region 返回
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <typeparam name="TResult">返回内容泛型</typeparam>
        /// <param name="result">结果内容</param>
        /// <returns></returns>
        protected virtual ContentResult ResultSuccess<TResult>(TResult result)
        {
            ResponseDto<TResult> response = new ResponseDto<TResult> { ResponseCode = ResponseCode.Success, Description = "success!", Content = result };
            return Content(JsonConvert.SerializeObject(response));
        }

        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="description">失败描述</param>
        /// <returns></returns>
        protected virtual ContentResult ResultFailure(string description)
        {
            ResponseDto<BaseVModel> response = new ResponseDto<BaseVModel> { ResponseCode = ResponseCode.Failure, Description = description, Content = null };
            return Content(JsonConvert.SerializeObject(response));
        }

        protected virtual ContentResult ResultDataGrid<T>(IList<T> data, Pager pager, object footer = null)
            where T : BaseVModel
        {
            DataGrid<T> gridData = new DataGrid<T>
            {
                rows = data.ToList(),
                total = pager.totalCount,
                footer = footer
            };
            return Content(JsonConvert.SerializeObject(gridData));
        }
        

        #endregion

        #region 重写方法
        
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            var platEx = filterContext.Exception as ApplicationException;
            ResponseDto<BaseVModel> response = new ResponseDto<BaseVModel> { ResponseCode = ResponseCode.Failure, Description = filterContext.Exception.Message, Content = null };
            
            filterContext.ExceptionHandled = true;
            filterContext.RequestContext.HttpContext.Response.Write(JsonConvert.SerializeObject(response));
            filterContext.RequestContext.HttpContext.Response.StatusCode = 200;
            filterContext.RequestContext.HttpContext.Response.End();

        }
        #endregion
    }
}