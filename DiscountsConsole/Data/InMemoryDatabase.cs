using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Data
{
    public class InMemoryDatabase : IDatabase
    {
        public InMemoryDatabase()
        {
            Products.Add(new Product("Sødmælk", 7, "Arla", "Netto"));
            Products.Add(new Product("Minimælk", 7, "Arla", "Netto"));
            Products.Add(new Product("Letmælk", 7, "Arla", "Netto"));
            Products.Add(new Product("Sødmælk", 8, "Thise", "Fakta"));
            Products.Add(new Product("Sødmælk", 9, "Arla", "Meny"));
            Products.Add(new Product("Sødmælk", 10, "Arla", "Aldi"));
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Brand> Brands { get; set; } = new List<Brand>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();
    }
}
