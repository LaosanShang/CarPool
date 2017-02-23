using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Models.Admin.MessageManage
{
    public class QueryConditionDto : BaseVModel
    {
        private string _startDate = DateTime.Now.ToString("yyyy-MM-dd");
        private string _endDate = DateTime.Now.ToString("yyyy-MM-dd");

        [Display(Name = "起点")]
        public string StartName { get; set; }
        [Display(Name = "出发开始日期")]
        public string StartTime { get { return _startDate; } set { _startDate = value; } }

        [Display(Name = "出发结束日期")]
        public string EndTime { get { return _endDate; } set { _endDate = value; } }

        [Display(Name = "消息类型")]
        public string MessageType { get; set; }
    }
}
