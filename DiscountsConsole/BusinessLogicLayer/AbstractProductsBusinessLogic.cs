using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public abstract class AbstractProductsBusinessLogic<T> : IBusinessLogic<T> where T : IProducts<Product>, IName, IDisplayable
    {
        protected AbstractDAL<T> DAL;

        protected AbstractProductsBusinessLogic(AbstractDAL<T> dAL)
        {
            DAL = dAL ?? throw new ArgumentNullException(nameof(dAL));
        }

        public List<T> PriceLessThan(List<T> entities, Stack<string> args)
        {
            var arg1 = double.Parse(args.Pop());
            foreach (var brand in entities)
            {
                brand.Products = brand.Products.PriceLessThan(arg1);
            }
            return entities.Where(brand => brand.Products.Count > 0).ToList();
        }

        public List<T> PriceRange(List<T> entities, Stack<string> args)
        {
            var arg1 = double.Parse(args.Pop());
            var arg2 = double.Parse(args.Pop());
            foreach (var brand in entities)
            {
                brand.Products = brand.Products.PriceRange(arg1, arg2);
            }
            return entities.Where(brand => brand.Products.Count > 0).ToList();
        }

        public List<T> PricerGreaterThan(List<T> entities, Stack<string> args)
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
            List<T> brands = DAL.Get();
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
            Console.WriteLine(brands.Print());
        }

        public List<T> Search(List<T> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            entities = entities.SearchByName(arg);
            return entities;
        }

        public List<T> Sort(List<T> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            if (arg.Equals("NAME")) entities = entities.SortByNameAscending();
            else throw new Exception("Invalid sorting parameter");
            return entities;
        }
    }
}
