using DiscountsConsole.BusinessLogicLayer;
using DiscountsConsole.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DiscountsConsole.Data
{
    /// <summary>
    /// DiscountsMongoDB acts as a Data Access Layer between the database and business logic and can be used interchangably with InMemoryDatabase
    /// </summary>
    public class DiscountsMongoDB : IDatabase
    {
        private IMongoDatabase db;

        public DiscountsMongoDB()
        {
            var client = new MongoClient();
            db = client.GetDatabase("DiscountsDatabase");
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
            RemoveEmptyBrandsAndSellers();
        }

        public void Delete(Seller t)
        {
            UpdateDefinition<Brand> update = Builders<Brand>.Update.PullFilter(brands => brands.Products, product => product.Seller == t.Name);
            Expression<Func<Brand, bool>> filter = brands => brands.Products.Any(product => product.Seller == t.Name);
            var result = Brands.UpdateMany(filter, update);
            var productsResult = Products.DeleteMany(s => s.Seller == t.Name);
            Sellers.FindOneAndDelete(s => s.Name == t.Name);
            RemoveEmptyBrandsAndSellers();
        }

        public void Delete(Brand t)
        {
            UpdateDefinition<Seller> update = Builders<Seller>.Update.PullFilter(seller => seller.Products, product => product.Brand == t.Name);
            Expression<Func<Seller, bool>> filter = seller => seller.Products.Any(product => product.Brand == t.Name);
            var result = Sellers.UpdateMany(filter, update);
            var productsResult = Products.DeleteMany(s => s.Brand == t.Name);
            Brands.FindOneAndDelete(s => s.Name == t.Name);
            RemoveEmptyBrandsAndSellers();
        }

        private void RemoveEmptyBrandsAndSellers()
        {
            var brandsResult = Brands.DeleteMany(s => s.Products.Count == 0);
            var sellersResult = Sellers.DeleteMany(s => s.Products.Count == 0);
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
