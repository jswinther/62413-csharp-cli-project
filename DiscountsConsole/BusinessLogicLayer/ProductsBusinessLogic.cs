using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTables;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class ProductsBusinessLogic : IBusinessLogic<Product>
    {
        ProductsDAL DAL;
        public ProductsBusinessLogic(ProductsDAL DAL)
        {
            this.DAL = DAL;

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

            var table = new ConsoleTable("Name", "Price", "Brand", "Seller");
            foreach (var item in products)
            {
                table.AddRow(item.Name, item.Price + ",-", item.Brand, item.Seller);
            }
            table.Write(Format.Alternative);
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
            var arg1 = args.Pop().ToUpper();
            var arg2 = args.Pop().ToUpper();
            if (arg1.Equals("NAME"))
            {
                if (arg2.Equals("ASC"))
                {
                    entities = entities.SortByNameAscending();
                }
                else if (arg2.Equals("DESC"))
                {
                    entities = entities.SortByNameDescending();
                }

                
            }
            else if (arg1.Equals("PRICE"))
            {
                if (arg2.Equals("ASC"))
                {
                    entities = entities.SortByPriceAscending();
                }
                else if (arg2.Equals("DESC"))
                {
                    entities = entities.SortByPriceDescending();
                }
                
            }
            else throw new Exception("Invalid sorting parameter");
            return entities;
        }
    }
}
