using System;
using System.Collections.Generic;
using System.Text;

namespace FNS.CRUDService.Model
{
    public class PagingQuery
    {
        public PagingOrder Order { get; set; }
        public PagingSearch Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
