using ConsoleTables;
using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class SellersBusinessLogic : IBusinessLogic<Seller>
    {
        protected IDatabase db;

        public SellersBusinessLogic(IDatabase db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public List<Seller> PriceLessThan(List<Seller> entities, Stack<string> args)
        {
            var arg1 = double.Parse(args.Pop());
            foreach (var brand in entities)
            {
                brand.Products = brand.Products.PriceLessThan(arg1);
            }
            return entities.Where(brand => brand.Products.Count > 0).ToList();
        }

        public List<Seller> PriceRange(List<Seller> entities, Stack<string> args)
        {
            var arg1 = double.Parse(args.Pop());
            var arg2 = double.Parse(args.Pop());
            foreach (var brand in entities)
            {
                brand.Products = brand.Products.PriceRange(arg1, arg2);
            }
            return entities.Where(brand => brand.Products.Count > 0).ToList();
        }

        public List<Seller> PricerGreaterThan(List<Seller> entities, Stack<string> args)
        {
            var arg1 = double.Parse(args.Pop());
            foreach (var brand in entities)
            {
                brand.Products = brand.Products.PriceGreaterThan(arg1);
            }
            return entities.Where(brand => brand.Products.Count > 0).ToList();
        }

        public void Run(Stack<string> args)
        {
            List<Seller> brands = db.GetSellers();
            while (args.Count > 0)
            {
                var flag = args.Pop().ToUpper();
                switch (flag)
                {
                    case "-SORT":
                        brands = Sort(brands, args);
                        break;
                    case "-NAMESEARCH":
                        brands = Search(brands, args);
                        break;
                    case "-PRICERANGE":
                        brands = PriceRange(brands, args);
                        break;
                    case "-PRICEGREATERTHAN":
                        brands = PricerGreaterThan(brands, args);
                        break;
                    case "-PRICELESSERTHAN":
                        brands = PriceLessThan(brands, args);
                        break;
                    default:
                        Console.WriteLine("No flags or args were passed, printing all products");
                        break;
                }
            }

            foreach (var item1 in brands)
            {
                Console.WriteLine(item1.Name);
                var table = new ConsoleTable("Name", "Price", "Brand", "Seller");
                foreach (var item in item1.Products)
                {
                    table.AddRow(item.Name, item.Price + ",-", item.Brand, item.Seller);
                }
                table.Write(Format.Alternative);
            }
        }

        public List<Seller> Search(List<Seller> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            entities = entities.SearchByName(arg);
            return entities;
        }

        public List<Seller> Sort(List<Seller> entities, Stack<string> args)
        {
            var arg1 = args.Pop().ToUpper();
            var arg2 = args.Pop().ToUpper();
            if (arg1.Equals("NAME"))
            {
                if (arg2.Equals("ASC"))
                {
                    entities = entities.SortByNameAscending();
                }
                else if (args.Equals("DESC"))
                {
                    entities = entities.SortByNameDescending();
                }

            }
            else if (arg1.Equals("PRICE"))
            {
                foreach (var entity in entities)
                {
                    if (arg2.Equals("ASC"))
                    {
                        entity.Products = entity.Products.SortByNameAscending();
                    }
                    else if (arg2.Equals("DESC"))
                    {
                        entity.Products = entity.Products.SortByNameDescending();
                    }
                }
            }
            else throw new Exception("Invalid sorting parameter");
            return entities;
        }
    }
}
