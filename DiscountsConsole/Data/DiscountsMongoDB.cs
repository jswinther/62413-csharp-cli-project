using DiscountsConsole.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
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

        public List<Brand> Brands => GetCollection<Brand>("Brands");

        public List<Product> Products => GetCollection<Product>("Products");

        public List<Seller> Sellers => GetCollection<Seller>("Sellers");

        public List<T> GetCollection<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }



    }
}
