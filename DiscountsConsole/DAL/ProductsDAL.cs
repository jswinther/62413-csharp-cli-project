using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.DAL
{
    public class ProductsDAL
    {
        Database db = new Database();
        public List<Product> Get()
        {
            return db.Products;
        }

        /// <summary>
        /// This method is meant for administrators, but this is a proof of concept.
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {

        }

        List<string> vs(List<IDisplayable> displayables)
        {
            List<string> s = new List<string>();
            foreach (var item in displayables)
            {
                s.Add(item.Display());
            }
            return s;
        }
    }
}
