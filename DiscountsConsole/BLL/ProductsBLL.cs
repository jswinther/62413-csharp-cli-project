using DiscountsConsole.DAL;
using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BLL
{
    public class ProductsBLL
    {
        ProductsDAL DAL;
        public ProductsBLL(IDatabase db)
        {
            DAL = new ProductsDAL(db.Products);

        }

        public void Get(string input = "")
        {
            var products = DAL.Get().Where(product => product.Name.Contains(input));
            foreach (var product in products)
            {
                Console.WriteLine(product.Display());            

                //Console.WriteLine(string.Join('\n', DAL.Get().Where(product => product.Seller == seller)));
            }
            
        }

        public List<Product> Sort(string strategy, out int mittal, out string minstreng)
        {
            var l = DAL.Get();
            switch (strategy)
            {
                case "price":
                    l.Sort(CompareByPrice);
                    break;
                case "name":
                    l.Sort(CompareByName);
                    break;
                default:
                    break;
            }
            mittal = 0;
            minstreng = "en string";
            return l;
        }

        public int CompareByName<T>(T x, T y) where T : IName
        {
            return x.Name.CompareTo(y.Name);
        }

        public int CompareByPrice<T>(T x, T y) where T : IPrice
        {
            return x.Price.CompareTo(y.Price);
        }

    }
}
