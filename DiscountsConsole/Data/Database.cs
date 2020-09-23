using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Data
{
    public class Database
    {
        public Database()
        {
            Products.Add(new Product("Sødmælk", 7, "Arla", "Netto"));
            Products.Add(new Product("Minimælk", 7, "Arla", "Netto"));
            Products.Add(new Product("Letmælk", 7, "Arla", "Netto"));
            Products.Add(new Product("Sødmælk", 8, "Thise", "Fakta"));
            Products.Add(new Product("Sødmælk", 9, "Arla", "Meny"));
            Products.Add(new Product("Sødmælk", 10, "Arla", "Aldi"));
        }

        public List<Product> Products { get; set; } = new List<Product>();

    }
}
