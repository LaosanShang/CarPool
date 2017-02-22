using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Db.Entities
{
    public class Message : BaseEntity
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
        public MessageType MessageType { get; set; }
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MessageVModel ToVModel()
        {
            return new MessageVModel
            {
                Id = this.Id,
                StartTime = this.StartTime,
                Description = this.Description,
                StartName = this.StartName,
                EndName = this.EndName,
                SeatCount = this.SeatCount,
                Contact = this.Contact,
                Price = this.Price,
                MessageType = MessageType.GetHashCode(),
                Phone = this.Phone
            };
        }
    }


    public enum MessageType
    {
        Passenger = 0,
        CarOwner = 1
    }
}