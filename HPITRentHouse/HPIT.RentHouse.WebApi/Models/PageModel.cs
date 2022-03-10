using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPIT.RentHouse.WebApi.Models
{
    public class PageModel
    {
        /// <summary>
        /// 重点数据，靠这个完成数据填充
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 总记录数（未过滤）
        /// </summary>
        public int recordsTotal { get; set; }

        /// <summary>
        /// 记录数（已过滤/检索）
        /// </summary>
        public int recordsFiltered { get; set; }
    }
}