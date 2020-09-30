using System;
using DiscountsConsole.Data;
using System.Linq;
using DiscountsConsole.BusinessLogicLayer;
using System.Collections.Generic;
using DiscountsConsole.Models;
using DiscountsConsole.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace DiscountsConsole
{
    class Program
    {
        

        static void Main()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<InMemoryDatabase>();
                    services.AddScoped<IContext, Context>();
                }).UseConsoleLifetime();


            string options = $"Options:" +
                   $"\n\t-Products\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Price|Name] [Asc|Desc]]" +
                   $"\n\t\t[-PriceRange [MinPrice, MaxPrice]]\n\t\t[-PriceGreaterThan [double]]" +
                   $"\n\t\t[-PriceLesserThan [double]]" +
                   $"\n\t-Brands\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Name] [Asc|Desc]]" +
                   $"\n\t-Sellers\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Name] [Asc|Desc]]" +
                   $"\n\t-Admin\n\t\t[-Add Product [params]]" +
                   $"\n\t-Help" +
                   $"\n\t Press Ctrl+C to exit";
            Console.WriteLine(options);
            while (true)
            {
                InMemoryDatabase db = new InMemoryDatabase();
                
                ProductsBusinessLogic productsBll = new ProductsBusinessLogic(new ProductsDAL(db.Products));
                BrandsBusinessLogic brandsBll = new BrandsBusinessLogic(new BrandsDAL(db.Brands));
                SellersBusinessLogic sellersBll = new SellersBusinessLogic(new SellerDAL(db.Sellers));
                var input = Console.ReadLine().Split(' ');
                Array.Reverse(input);
                Stack<string> args = new Stack<string>(input);
                var arg = args.Pop().ToUpper();
                switch (arg)
                {
                    case "-PRODUCTS":
                        productsBll.Run(args);
                        break;
                    case "-BRANDS":
                        brandsBll.Run(args);
                        break;
                    case "-SELLERS":
                        sellersBll.Run(args);
                        break;
                    case "-HELP":
                        Console.WriteLine(options);
                        break;
                    default:
                        Console.WriteLine($"Invalid args {arg}");
                        break;
                }
            }
        }
    }
}
