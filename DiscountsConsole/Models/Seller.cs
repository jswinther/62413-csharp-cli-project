using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Models
{
    public class Seller : IDisplayable, IName, IProducts
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public string Display()
        {
            throw new NotImplementedException();
        }
    }
}
