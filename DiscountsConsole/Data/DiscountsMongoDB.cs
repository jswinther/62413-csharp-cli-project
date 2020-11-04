using DiscountsConsole.BusinessLogicLayer;
using DiscountsConsole.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.Data
{
    public class DiscountsMongoDB : IDatabase
    {
        private IMongoDatabase db;

        public DiscountsMongoDB()
        {
            var client = new MongoClient();
            db = client.GetDatabase("DiscountsDatabase");
            /*
            var brands = Products.Select(f => f.Brand).Distinct().Select(s => new Brand { Name = s, Products = Products.Where(e => e.Brand == s).ToList()}).Distinct();
            var sellers = Products.Select(f => f.Seller).Distinct().Select(s => new Seller { Name = s, Products = Products.Where(e => e.Seller == s).ToList() }).Distinct();
            db.GetCollection<Brand>("Brands").InsertMany(brands);
            db.GetCollection<Seller>("Sellers").InsertMany(sellers);
            Console.WriteLine();
            */
        }

        private IMongoCollection<Brand> Brands => db.GetCollection<Brand>("Brands");

        private IMongoCollection<Product> Products => db.GetCollection<Product>("Products");

        private IMongoCollection<Seller> Sellers => db.GetCollection<Seller>("Sellers");

        public void Add(Product t)
        {
            if (Products.AsList().Any(s => s.Brand == t.Brand && s.Name == t.Name && s.Price == t.Price && s.Seller == t.Seller))
            {
                throw new Exception("Duplicate product");
            }
            Products.InsertOne(t);
            if (Sellers.AsList().Select(s => s.Name).Contains(t.Seller))
            {
                //Sellers.FindOneAndUpdate(e => e.Name == t.Seller, Builders<Seller>.Update.Set(e => e.Products.Add(t)));
            }
            else
            {
                Add(new Seller { Name = t.Seller, Products = new List<Product> { t } });
            }

            if (Brands.AsList().Select(s => s.Name).Contains(t.Brand))
            {
                //Brands.FindOneAndUpdate(e => e.Name == t.Brand, Builders<Brand>.Update.Set(e => e.Products.Add(t)));
            }
            else
            {
                Add(new Brand { Name = t.Brand, Products = new List<Product> { t } });
            }
        }

        public void Add(Seller t)
        {
            Sellers.InsertOne(t);
        }

        public void Add(Brand t)
        {
            Brands.InsertOne(t);
        }

        public List<Brand> GetBrands()
        {
            return Brands.AsList();
        }

        public List<Product> GetProducts()
        {
            return Products.AsList();
        }

        public List<Seller> GetSellers()
        {
            return Sellers.AsList();
        }
    }
}
