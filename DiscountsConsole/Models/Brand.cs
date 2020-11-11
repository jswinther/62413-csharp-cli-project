using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DiscountsConsole.Models
{
    [DebuggerDisplay("Name = {Name}")]
    public class Brand : IName, IProducts<Product>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
