using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Models
{
    public class Product : IDisplayable, IName, IPrice
    {
        public Product(string name, double price, string brand, string seller)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Seller = seller ?? throw new ArgumentNullException(nameof(seller));
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Seller { get; set; }

        public string Display()
        {
            return $"{Name}\t{Price}\t{Brand}\t{Seller}";
        }
    }
}
