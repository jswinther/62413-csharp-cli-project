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
            if (!Products.AsList().Any(s => s.Brand == t.Brand && s.Name == t.Name && s.Price == t.Price && s.Seller == t.Seller))
            {
                Products.InsertOne(t);
            }
            else
            {
                Console.WriteLine("Product already exists");
                return;
            }
            
            if (Sellers.AsList().Select(s => s.Name).Contains(t.Seller))
            {
                FilterDefinition<Seller> filter = Builders<Seller>
                    .Filter.Eq(e => e.Name, t.Seller);
                UpdateDefinition<Seller> update = Builders<Seller>.Update
                    .Push(e => e.Products, t);
                Sellers.FindOneAndUpdate(filter, update);
            }
            else
            {
                Add(new Seller { Name = t.Seller, Products = new List<Product> { t } });
            }

            if (Brands.AsList().Select(s => s.Name).Contains(t.Brand))
            {

                FilterDefinition<Brand> filter = Builders<Brand>
                    .Filter.Eq(e => e.Name, t.Brand);
                UpdateDefinition<Brand> update = Builders<Brand>.Update
                    .Push(e => e.Products, t);
                Brands.FindOneAndUpdate(filter, update);
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

        


        public void Delete(Product t)
        {
            if (!Products.AsList().Any(s => s.Brand == t.Brand && s.Name == t.Name && s.Price == t.Price && s.Seller == t.Seller))
            {
                Console.WriteLine("Product doesn't exists");
                return;
            }
          
            if (Sellers.AsList().Select(s => s.Name).Contains(t.Seller))
            {
                FilterDefinition<Seller> filter = Builders<Seller>
                    .Filter.Eq(e => e.Name, t.Seller);
                UpdateDefinition<Seller> update = Builders<Seller>.Update.PullFilter(s => s.Products, f => f.Brand == t.Brand && f.Seller == t.Seller && f.Price == t.Price && f.Name == t.Name);
                var result = Sellers.FindOneAndUpdate(filter, update);
            }

            if (Brands.AsList().Select(s => s.Name).Contains(t.Brand))
            {

                FilterDefinition<Brand> filter = Builders<Brand>
                    .Filter.Eq(e => e.Name, t.Brand);
                UpdateDefinition<Brand> update = Builders<Brand>.Update.PullFilter(s => s.Products, f => f.Brand == t.Brand && f.Seller == t.Seller && f.Price == t.Price && f.Name == t.Name);
                var result = Brands.FindOneAndUpdate(filter, update);
            }

            Products.FindOneAndDelete(p => p.Name == t.Name && p.Price == t.Price && p.Brand == t.Brand && p.Seller == t.Seller);

            
            var brandsResult = Brands.DeleteMany(s => s.Products.Count == 0);
            var sellersResult = Sellers.DeleteMany(s => s.Products.Count == 0);
        }

        // Bør vi kunne slette sellers?
        public void Delete(Seller t)
        {
            Sellers.FindOneAndDelete(s => s.Name == t.Name);
        }

        // Bør vi kunne slette brands?
        public void Delete(Brand t)
        {
            Brands.FindOneAndDelete(s => s.Name == t.Name);
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
