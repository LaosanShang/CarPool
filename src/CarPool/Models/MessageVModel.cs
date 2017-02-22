using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Models
{
    public class MessageVModel : BaseVModel
    {
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int Ticks { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public int MessageType { get; set; }
        /// <summary>
        /// 起点
        /// </summary>
        public string StartName { get; set; }
        /// <summary>
        /// 终点
        /// </summary>
        public string EndName { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 座位数
        /// </summary>
        public int SeatCount { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}