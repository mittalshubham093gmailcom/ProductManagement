using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public List<Product> products { get; set; }
    }
}
