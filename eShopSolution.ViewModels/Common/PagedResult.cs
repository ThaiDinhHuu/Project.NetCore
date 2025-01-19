using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Common
{
    public class Pagedresult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
