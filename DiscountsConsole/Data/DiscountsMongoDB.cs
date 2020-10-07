using DiscountsConsole.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
