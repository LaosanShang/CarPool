using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Models.Admin.UserManage
{
    public class QueryConditionDto : BaseVModel
    {
        [Display(Name = "用户名")]
        public string UserName { get; set; }
    }
}
