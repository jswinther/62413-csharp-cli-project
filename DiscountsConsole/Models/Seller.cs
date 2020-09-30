using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Models
{
    public class Seller : IDisplayable, IName, IProducts<Product>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public string Display()
        {
            string display = Name + "\n";
            foreach (var product in Products)
            {
                display += $"\t{product.Display()}\n";
            }
            return display;
        }
    }
}
