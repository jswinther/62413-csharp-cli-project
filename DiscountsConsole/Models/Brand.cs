using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Models
{
    public class Brand : IDisplayable, IName, IProducts, IPrice
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Display()
        {
            throw new NotImplementedException();
        }
    }
}
