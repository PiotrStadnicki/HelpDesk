using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskApi.Models
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemFrom { get; set; }
        public int IntemsTo { get; set; }
        public int TotalItemCount { get; set; }

        public PageResult(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItemCount = totalCount;
            ItemFrom = pageSize * (pageNumber - 1) + 1;
            IntemsTo = ItemFrom + pageSize - 1;
            TotalPages =(int)Math.Ceiling( totalCount /(double) pageSize);
        }
            



    }
}
