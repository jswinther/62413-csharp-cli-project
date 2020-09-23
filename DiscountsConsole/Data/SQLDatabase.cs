using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Data
{
    public class SQLDatabase : IDatabase
    {
        public List<Brand> Brands { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Product> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Seller> Sellers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
