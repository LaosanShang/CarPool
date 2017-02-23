
using System.ComponentModel.DataAnnotations;

namespace CarPool.Models.Admin.UserManage
{
    public class UserDto : BaseVModel
    {
        public UserDto()
        {
            
        }
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public string Sex { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        public string Phone { get; set; }
    }
}
