using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Db.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
    }
}