using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Models
{
    public class Product : IName, IPrice
    {
        public Product(string name, double price, string brand, string seller)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Seller = seller ?? throw new ArgumentNullException(nameof(seller));
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Seller { get; set; }
    }
}
