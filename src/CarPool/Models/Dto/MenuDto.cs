using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPool.Models.Dto
{
    public class MenuDto : BaseVModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 父级菜单ID
        /// </summary>
        public string ParentId { get; set; }

        public List<MenuDto> Children { get; set; }

    }
}