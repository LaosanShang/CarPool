using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Models
{
    public class IndexVModel : BaseVModel
    {
        public IndexVModel()
        {
            CarMessages = new List<MessageVModel>();
            PassengerMessages = new List<MessageVModel>();
        }
        /// <summary>
        /// 消息列表 - 找车
        /// </summary>
        public List<MessageVModel> CarMessages { get; set; }
        /// <summary>
        /// 消息列表 - 找人
        /// </summary>
        public List<MessageVModel> PassengerMessages { get; set; }
    }
}