using System.Collections.Generic;

namespace FNS.CRUDService.Model
{
    public class PagingResult
    {
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public int PageIndex { get; set; }
        public List<dynamic> Data { get; set; }
    }
}
