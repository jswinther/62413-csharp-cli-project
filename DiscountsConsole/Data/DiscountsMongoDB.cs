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
            Products.InsertOne(t);
        }

        public void Add(Seller t)
        {
            Sellers.InsertOne(t);
        }

        public void Add(Brand t)
        {
            Brands.InsertOne(t);
        }

        public List<T> Get<T>() where T : class
        {
            switch (typeof(T).Name)
            {
                case "Product":
                    return Products.AsList();
                default:
                    break;
            }
        }

        public List<Product> Get()
        {
            return Products.AsList();
        }

        List<Seller> IDatabaseCollection<Seller>.Get()
        {
            return Sellers.AsList();
        }

        List<Brand> IDatabaseCollection<Brand>.Get()
        {
            return Brands.AsList();
        }
    }
}
