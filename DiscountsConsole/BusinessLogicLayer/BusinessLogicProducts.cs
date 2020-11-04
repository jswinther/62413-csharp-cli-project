﻿using ConsoleTables;
using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class BusinessLogicProducts<T> : IBusinessLogic<T> where T : IProducts<Product>, IName
    {
        protected AbstractDAL<T> DAL;

        public BusinessLogicProducts(AbstractDAL<T> dAL)
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

        public List<T> Search(List<T> entities, Stack<string> args)
        {
            var arg = args.Pop().ToUpper();
            entities = entities.SearchByName(arg);
            return entities;
        }

        public List<T> Sort(List<T> entities, Stack<string> args)
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