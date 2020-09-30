using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class ProductsBusinessLogic : IBusinessLogic
    {
        ProductsDAL DAL;
        public ProductsBusinessLogic(IDatabase db)
        {
            DAL = new ProductsDAL(db.Products);

        }

        public void Run(Stack<string> args)
        {
            List<Product> products = DAL.Get();
            while (args.Count > 0)
            {
                var flag = args.Pop().ToUpper();
                
                switch (flag)
                {
                    case "-SORT":
                        products = Sort(products, args);
                        Console.WriteLine(products.Print());
                        break;
                    case "-NAMESEARCH":
                        products = Search(products, args);
                        Console.WriteLine(products.Print());
                        break;
                    case "-PRICERANGE":
                        products = PriceRange(products, args);
                        Console.WriteLine(products.Print());
                        break;
                    default:
                        break;
                }
            }
        }

        private static List<Product> PriceRange(List<Product> products, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            var maxprice = int.Parse(args.Pop());
            products = products.PriceRange(int.Parse(arg), maxprice);

            return products;
        }

        private static List<Product> Search(List<Product> products, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            products = products.SearchByName(arg);
            return products;
        }

        private static List<Product> Sort(List<Product> products, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            if (arg.Equals("NAME")) products = products.SortByNameAscending();
            else if (arg.Equals("PRICE")) products = products.SortByPriceAscending();
            else throw new Exception("Invalid sorting parameter");
            return products;
        }
    }
}
