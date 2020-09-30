using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class ProductsBusinessLogic : IBusinessLogic<Product>
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
                        break;
                    case "-NAMESEARCH":
                        products = Search(products, args);
                        break;
                    case "-PRICERANGE":
                        products = PriceRange(products, args);
                        break;
                    case "-PRICEGREATERTHAN":
                        products = PricerGreaterThan(products, args);
                        break;
                    case "-PRICELESSERTHAN":
                        products = PriceLessThan(products, args);
                        break;
                    default:
                        Console.WriteLine("No flags or args were passed, printing all products");
                        break;
                }
            }
            
            Console.WriteLine(products.Print());
        }

        public List<Product> PriceLessThan(List<Product> entities, Stack<string> args)
        {
            var arg = args.Pop();
            entities = entities.PriceLessThan(double.Parse(arg));
            return entities;
        }

        public List<Product> PricerGreaterThan(List<Product> entities, Stack<string> args)
        {
            var arg = args.Pop();
            entities = entities.PriceGreaterThan(double.Parse(arg));
            return entities;
        }

        public List<Product> PriceRange(List<Product> entities, Stack<string> args)
        {
            var arg = args.Pop();
            var maxprice = double.Parse(args.Pop());
            entities = entities.PriceRange(double.Parse(arg), maxprice);
            return entities;
        }

        public List<Product> Search(List<Product> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            entities = entities.SearchByName(arg);
            return entities;
        }

        public List<Product> Sort(List<Product> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            if (arg.Equals("NAME")) entities = entities.SortByNameAscending();
            else if (arg.Equals("PRICE")) entities = entities.SortByPriceAscending();
            else throw new Exception("Invalid sorting parameter");
            return entities;
        }
    }
}
