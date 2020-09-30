using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Models
{
    public class Brand : IName, IProducts<Product>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
