using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPool.Models
{
    public class UserVModel :BaseVModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入您的姓名！")]
        [Display(Name = "姓名")]
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "请选择性别！")]
        [Display(Name = "性别")]
        public string Sex { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Required(ErrorMessage = "请输入您的联系电话！")]
        [Phone(ErrorMessage ="请您输入正确的联系电话")]
        [Display(Name = "联系电话")]
        public string Phone { get; set; }
    }
}