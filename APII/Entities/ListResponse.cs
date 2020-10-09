using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APII.Entities
{
    public class ListResponse<T> where T : class
    {
        public int TotalItems { get; set; }

        public List<T> Items { get; set; }
    }
}
