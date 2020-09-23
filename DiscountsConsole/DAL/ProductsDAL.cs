﻿using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.DAL
{
    public class ProductsDAL : AbstractDAL<Product>
    {
        public ProductsDAL(List<Product> list) : base(list)
        {
        }
    }
}