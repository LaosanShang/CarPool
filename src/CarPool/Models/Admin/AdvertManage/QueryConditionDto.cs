using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Models.Admin.AdvertManage
{
    public class QueryConditionDto : BaseVModel
    {
        [Display(Name = "标题")]
        public string Title { get; set; }
    }
}
