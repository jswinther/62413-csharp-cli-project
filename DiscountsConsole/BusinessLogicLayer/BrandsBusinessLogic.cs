using ConsoleTables;
using DiscountsConsole.Data;
using DiscountsConsole.Exceptions;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class BrandsBusinessLogic : IBusinessLogic<Brand>
    {
        protected IDatabase db;

        public BrandsBusinessLogic(IDatabase db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public List<Brand> PriceLessThan(List<Brand> entities, Stack<string> args)
        {
            var arg1 = double.Parse(args.Pop());
            foreach (var brand in entities)
            {
                brand.Products = brand.Products.PriceLessThan(arg1);
            }
            return entities.Where(brand => brand.Products.Count > 0).ToList();
        }

        public List<Brand> PriceRange(List<Brand> entities, Stack<string> args)
        {
            var arg1 = double.Parse(args.Pop());
            var arg2 = double.Parse(args.Pop());
            foreach (var brand in entities)
            {
                brand.Products = brand.Products.PriceRange(arg1, arg2);
            }
            return entities.Where(brand => brand.Products.Count > 0).ToList();
        }

        public List<Brand> PricerGreaterThan(List<Brand> entities, Stack<string> args)
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
            List<Brand> brands = db.GetBrands();
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

        internal void Add(Stack<string> args)
        {
            throw new NotImplementedException();
        }

        public List<Brand> Search(List<Brand> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            entities = entities.SearchByName(arg);
            return entities;
        }

        internal void Delete(Stack<string> args)
        {
            db.Delete(new Brand { Name = args.Pop() });
        }

        public List<Brand> Sort(List<Brand> entities, Stack<string> args)
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
                else if (args.Equals("DESC"))
                {
                    entities = entities.SortByNameDescending();
                }
                else throw new InvalidParameterException($"Expected ASC or DESC for sorting direction, but received {arg2}");
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
                    else throw new InvalidParameterException($"Expected ASC or DESC for sorting direction, but received {arg2}");
                }
            }
            else throw new InvalidParameterException($"Invalid sorting parameter {arg1}");
            return entities;
        }
    }
}
