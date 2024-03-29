﻿using DiscountsConsole.Models;
using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.Data
{
    public class InMemoryDatabase : IDatabase
    {
        public InMemoryDatabase()
        {
            // Aldi tilbudsavis
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
            Products.Add(new Product("Yoghurt", 14, "yoggi", "Aldi"));
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

            // Fakta tilbudsavis
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

            // Netto tilbudsavis
            Products.Add(new Product("Bleer", 89, "Libero Touch", "Netto"));
            Products.Add(new Product("Coca Cola", 11, "Coca Cola", "Netto"));
            Products.Add(new Product("Hakket oksekød 14-18%", 15, "Velsmag", "Netto"));
            Products.Add(new Product("Cremefine", 5, "Cremefine", "Netto"));
            Products.Add(new Product("Tomatsauce", 9, "Dolmio", "Netto"));
            Products.Add(new Product("Toiletpapir", 10, "Godt papir", "Netto"));
            Products.Add(new Product("Hjemmesko", 20, "Spot-vare", "Netto"));
            Products.Add(new Product("Plastboks med låg", 35, "Spot-vare", "Netto"));
            Products.Add(new Product("Veggie Pålæg 70g", 8, "Den grønne slagter", "Netto"));
            Products.Add(new Product("Rullepølse 70g", 8, "Den grønne slagter", "Netto"));
            Products.Add(new Product("Kyllingebryst 70g", 8, "Den grønne slagter", "Netto"));
            Products.Add(new Product("Hel Kylling 1500g", 79, "Legismose", "Netto"));
            Products.Add(new Product("Hel Kylling 1350g", 29, "Velsmag", "Netto"));
            Products.Add(new Product("Torskefars", 15, "Havfisk", "Netto"));
            Products.Add(new Product("Laksefars", 15, "Havfisk", "Netto"));
            Products.Add(new Product("Asparges Suppe", 18, "Knorr", "Netto"));
            Products.Add(new Product("Karry Suppe", 18, "Knorr", "Netto"));
            Products.Add(new Product("Goulash Suppe", 18, "Knorr", "Netto"));
            Products.Add(new Product("Tomat Suppe", 18, "Knorr", "Netto"));
            Products.Add(new Product("Mozzarella", 10, "Galbani", "Netto"));
            Products.Add(new Product("Prosciutto Pizza", 20, "Premieur", "Netto"));
            Products.Add(new Product("Meat Speciale Pizza", 20, "Premieur", "Netto"));
            Products.Add(new Product("Mozzarella Pizza", 20, "Premieur", "Netto"));
            Products.Add(new Product("Multi Juice", 10, "Nikoline", "Netto"));
            Products.Add(new Product("Mountain Blast", 10, "Powerrade", "Netto"));
            Products.Add(new Product("Blue Keld B Free", 10, "Blue Keld", "Netto"));
            Products.Add(new Product("Vanilje Yoghurt", 9, "Cheasy", "Netto"));
            Products.Add(new Product("Skovbær Yoghurt", 9, "Cheasy", "Netto"));
            Products.Add(new Product("Jordbær & Rabarber Yoghurt", 9, "Cheasy", "Netto"));
            Products.Add(new Product("Natural Skyr", 19, "Legismose", "Netto"));
            Products.Add(new Product("Vanilje Skyr", 19, "Legismose", "Netto"));
            Products.Add(new Product("Pære & Banan Skyr", 19, "Legismose", "Netto"));


            foreach (var brand in Products.Select(product => product.Brand).Distinct())
            {
                Brands.Add(new Brand { Name = brand, Products = Products.Where(prod => prod.Brand == brand).ToList() });
            }

            foreach (var seller in Products.Select(product => product.Seller).Distinct())
            {
                Sellers.Add(new Seller { Name = seller, Products = Products.Where(prod => prod.Seller == seller).ToList() });
            }
        }

        private List<Product> Products { get; } = new List<Product>();
        private List<Brand> Brands { get; } = new List<Brand>();
        private List<Seller> Sellers { get; } = new List<Seller>();

        public void Delete(Product t)
        {
            var result = Products.Remove(t);
            Sellers.ForEach(s => s.Products.Remove(t));
            Brands.ForEach(s => s.Products.Remove(t));
            DeleteBrandsAndSellersWithNoProducts();
        }

        public void Delete(Seller t)
        {
            Products.RemoveAll(product => product.Seller == t.Name);
            Brands.ForEach(brand => brand.Products.RemoveAll(product => product.Seller == t.Name));
            var result = Sellers.RemoveAll(seller => seller.Name == t.Name);
            DeleteBrandsAndSellersWithNoProducts();
        }

        public void Delete(Brand t)
        {
            Products.RemoveAll(s => s.Brand == t.Name);
            Sellers.ForEach(seller => seller.Products.RemoveAll(product => product.Brand == t.Name));
            var result = Brands.RemoveAll(brand => brand.Name == t.Name);
            DeleteBrandsAndSellersWithNoProducts();
        }

        private void DeleteBrandsAndSellersWithNoProducts()
        {
            Sellers.RemoveAll(s => s.Products.Count == 0);
            Brands.RemoveAll(s => s.Products.Count == 0);
        }

        public void Add(Product t)
        {
            Products.Add(t);
            try
            {
                Sellers.FirstOrDefault(seller => seller.Name == t.Seller).Products.Add(t);
            }
            catch (Exception)
            {
                Add(new Seller { Name = t.Seller, Products = new List<Product> { t } });
            }

            try
            {
                Brands.FirstOrDefault(brands => brands.Name == t.Brand).Products.Add(t);
            }
            catch (Exception)
            {
                Add(new Brand { Name = t.Brand, Products = new List<Product> { t } });
            }
        }

        public void Add(Seller t)
        {
            Sellers.Add(t);

        }

        public void Add(Brand t)
        {
            Brands.Add(t);
        }

        public List<Brand> GetBrands()
        {
            return Brands.ToList();
        }

        public List<Product> GetProducts()
        {
            return Products.ToList();
        }

        public List<Seller> GetSellers()
        {
            return Sellers.ToList();
        }
    }
}
