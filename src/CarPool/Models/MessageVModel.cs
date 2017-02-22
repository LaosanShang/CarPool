using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// 0 : 车主信息
        /// 1 : 乘客信息
        /// </summary>
        public int MessageType { get; set; }
        /// <summary>
        /// 起点
        /// </summary>
        [Required(ErrorMessage ="请您输入起点")]
        public string StartName { get; set; }
        /// <summary>
        /// 终点
        /// </summary>
        [Required(ErrorMessage = "请您输入终点?")]
        public string EndName { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        [Required(ErrorMessage = "请您选择出发时间！")]
        public string StartTime { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [Required(ErrorMessage = "请输入价格！")]
        [Range(0,9999,ErrorMessage = "请输入有效的金额！")]
        public decimal Price { get; set; }
        /// <summary>
        /// 座位数
        /// </summary>
        [Required(ErrorMessage = "请输入座位数")]
        [RegularExpression("^[1-9][0-9]$", ErrorMessage = "您输入的座位数格式不正确!")]
        public int SeatCount { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Required(ErrorMessage = "请输入联系人的姓名！")]
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Required(ErrorMessage = "请输入您的联系电话！")]
        [Phone(ErrorMessage = "您输入的电话号码的格式不正确！")]
        public string Phone { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(300,ErrorMessage = "描述最多只能输入300个字符！")]
        public string Description { get; set; }
    }
}