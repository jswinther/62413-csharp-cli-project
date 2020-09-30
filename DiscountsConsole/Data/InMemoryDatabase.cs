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

            Products.Add(new Product("Solgryn", 28, "Ota", "Aldi"));
            Products.Add(new Product("XXL Schnitzel", 24, "Worlds kitchen", "Aldi"));
            Products.Add(new Product("Skæreost", 45, "Them", "Aldi"));
            Products.Add(new Product("Delikatesser", 10, "pålækker", "Aldi"));
            Products.Add(new Product("Jolly cola", 7, "jolly", "Aldi"));
            Products.Add(new Product("redbull", 39, "redbull", "Aldi"));
            Products.Add(new Product("Flødeboller", 20, "Samba", "Aldi"));
            Products.Add(new Product("Brødblandinger", 12, "Valsmøllen", "Aldi"));
            Products.Add(new Product("Bacon i skiver", 5, "Gierlinger", "Aldi"));
            Products.Add(new Product("Joe' kurt", 15, "naturli'", "Aldi"));
            Products.Add(new Product("Mælkesnitte", 15, "kinder", "Aldi"));
            Products.Add(new Product("Småkager", 10, "Nordthy", "Aldi"));
            Products.Add(new Product("Indbagt laksefilet", 20, "Rahbek", "Aldi"));
            Products.Add(new Product("Kalvecuvette", 45, "landlyst", "Aldi"));
            Products.Add(new Product("Hakket kød", 49, "landlyst", "Aldi"));
            Products.Add(new Product("minipizza", 10, "pigga", "Aldi"));
            Products.Add(new Product("Solsikkerugbrød", 12, "Kohberg", "Aldi"));
            Products.Add(new Product("Shampoo", 20, "head and shoulders", "Aldi"));
            Products.Add(new Product("Morgenmad", 35, "nestle", "Aldi"));
            Products.Add(new Product("Yogurt", 14, "yoggi", "Aldi"));
            Products.Add(new Product("Smoothie", 10, "Froosh", "Aldi"));
            Products.Add(new Product("kartoffelsuppe", 12, "La finesse", "Aldi"));
            Products.Add(new Product("Ellebryg", 10, "Skovlyst", "Aldi"));
            Products.Add(new Product("markrelfilet", 45, "Sæby", "Aldi"));
            Products.Add(new Product("Original chips", 12, "pringles", "Aldi"));
            Products.Add(new Product("Bloklys", 18, "asp holmblad", "Aldi"));
            Products.Add(new Product("chelsea støvler", 139, "walkx", "Aldi"));
            Products.Add(new Product("Armbåndsur", 79, "krontaler", "Aldi"));
            Products.Add(new Product("Sengesæt", 129, "Quality textiles", "Aldi"));
            Products.Add(new Product("Stolehynder", 99, "Quality textiles", "Aldi"));
            Products.Add(new Product("kroge i træ", 49, "FSC", "Aldi"));


            Products.Add(new Product("Cheddar", 9, "Coop", "Fakta"));
            Products.Add(new Product("Brød", 12, "Schulstad", "Fakta"));
            Products.Add(new Product("Flødeboller", 19, "Spangsberg", "Fakta"));
            Products.Add(new Product("Løg", 6, "Coop", "Fakta"));
            Products.Add(new Product("Hel kylling", 45, "Rose", "Fakta"));
            Products.Add(new Product("Skæreost", 39, "thiese", "Fakta"));
            Products.Add(new Product("Skyr", 25, "365økologi", "Fakta"));
            Products.Add(new Product("Brutalis øl", 6, "Brutalis", "Fakta"));
            Products.Add(new Product("Jolly cola", 7, "Jolly", "Fakta"));
            Products.Add(new Product("Cocio original", 5, "Cocio", "Fakta"));
            Products.Add(new Product("Solgryn", 14, "Ota", "Fakta"));
            Products.Add(new Product("Franske valfer", 10, "karen volf", "Fakta"));
            Products.Add(new Product("SkildpAdde is", 25, "premier is", "Fakta"));
            Products.Add(new Product("Biksemad", 16, "steff houlberg", "Fakta"));
            Products.Add(new Product("forårsruller", 20, "Daloon", "Fakta"));
            Products.Add(new Product("honning", 15, "jakobsens", "Fakta"));
            Products.Add(new Product("markrelfilet", 12, "Amanda", "Fakta"));
            Products.Add(new Product("Smøreost", 9, "Philadelphia", "Fakta"));
            Products.Add(new Product("Karrysild", 10, "xtra", "Fakta"));
            Products.Add(new Product("Æbleskiver", 12, "coop", "Fakta"));
            Products.Add(new Product("Chokoladerulle", 10, "marabou", "Fakta"));
            Products.Add(new Product("Klinkerens", 15, "ajax", "Fakta"));
            Products.Add(new Product("Tandbørste", 20, "colgate", "Fakta"));

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
