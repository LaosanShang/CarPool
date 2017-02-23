using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Db.Entities
{
    /// <summary>
    /// 广告
    /// </summary>
    public class Advert : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}