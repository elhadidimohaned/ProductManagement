using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; private set; }
        public int TotalCount { get; private set; }

        public PaginatedList(List<T> items, int count)
        {
            Items = items;
            TotalCount = count;
        }
    }
}
