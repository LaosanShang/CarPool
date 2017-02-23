using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Models.Admin.MessageManage
{
    public class PageDto
    {
        public PageDto()
        {
            QueryForm = new QueryConditionDto();
        }
        public QueryConditionDto QueryForm { get; set; }
    }
}
