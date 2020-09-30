using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (var brand in Products.Select(product => product.Brand).Distinct())
            {
                Brands.Add(new Brand { Name = brand, Products = Products.Where(prod => prod.Brand == brand).ToList() });
            }

            foreach (var seller in Products.Select(product => product.Seller).Distinct())
            {
                Sellers.Add(new Seller { Name = seller, Products = Products.Where(prod => prod.Seller == seller).ToList() });
            }
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Brand> Brands { get; set; } = new List<Brand>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();
    }
}
