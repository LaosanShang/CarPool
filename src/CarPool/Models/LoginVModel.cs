using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPool.Models
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public class LoginVModel
    {
        [Required(ErrorMessage = "请输入您的联系电话！")]
        [Phone(ErrorMessage = "请您输入正确的联系电话")]
        [Display(Name = "联系电话")]
        public string Phone { get; set; }
    }
}