using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTables;
using DiscountsConsole.Exceptions;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class ProductsBusinessLogic : IBusinessLogic<Product>
    {
        IDatabase db;
        public ProductsBusinessLogic(IDatabase db)
        {
            this.db = db;

        }

        public void Run(Stack<string> args)
        {
            List<Product> products = db.GetProducts();
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
            var maxprice = args.Pop();
            entities = entities.PriceLessThan(double.Parse(maxprice));
            return entities;
        }

        public List<Product> PricerGreaterThan(List<Product> entities, Stack<string> args)
        {
            var minprice = args.Pop();
            entities = entities.PriceGreaterThan(double.Parse(minprice));
            return entities;
        }

        public List<Product> PriceRange(List<Product> entities, Stack<string> args)
        {
            var minprice = args.Pop();
            var maxprice = double.Parse(args.Pop());
            entities = entities.PriceRange(double.Parse(minprice), maxprice);
            return entities;
        }

        public List<Product> Search(List<Product> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            entities = entities.SearchByName(arg);
            return entities;
        }

        internal void Add(Stack<string> args)
        {
            var name = args.Pop();
            var price = double.Parse(args.Pop());
            var brand = args.Pop();
            var seller = args.Pop();
            var product = new Product(name, price, brand, seller);
            db.Add(product);
        }

        internal void Delete(Stack<string> args)
        {
            var name = args.Pop();
            var price = double.Parse(args.Pop());
            var brand = args.Pop();
            var seller = args.Pop();
            var product = new Product(name, price, brand, seller);
            db.Delete(product); // Sender bare produktet med. Er det smartere hvis vi sender navn, pris, brand og seller med i stedet?
        }

        public List<Product> Sort(List<Product> entities, Stack<string> args)
        {
            if (!args.TryPop(out string arg1)) throw new InvalidParameterException($"Expected PRICE or NAME for sorting direction, but received nothing");
            if (!args.TryPop(out string arg2)) throw new InvalidParameterException($"Expected ASC or DESC for sorting direction, but received nothing");
            arg1 = arg1.ToUpper();
            arg2 = arg2.ToUpper();
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
                else throw new InvalidParameterException($"Expected ASC or DESC for sorting direction, but received {arg2}");
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
                else throw new InvalidParameterException($"Expected ASC or DESC for sorting direction, but received {arg2}");
            }
            else throw new InvalidParameterException($"Invalid sorting parameter expected NAME or PRICE, but received {arg1}");
            return entities;
        }
    }
}
