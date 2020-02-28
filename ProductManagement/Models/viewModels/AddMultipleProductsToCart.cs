using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models.viewModels
{
    public class MultipleProductsCartViewModel
    {
        public int CartId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
