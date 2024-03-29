﻿using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.Data
{
    public interface IDatabase
    {
        public void Add(Brand t);
        public void Delete(Brand t);
        public List<Brand> GetBrands();
        public void Add(Product t);
        public void Delete(Product t);
        public List<Product> GetProducts();
        public void Add(Seller t);
        public void Delete(Seller t);
        public List<Seller> GetSellers();
    }
}