using System;
using DiscountsConsole.Data;
using System.Linq;
using DiscountsConsole.BusinessLogicLayer;
using System.Collections.Generic;
using DiscountsConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace DiscountsConsole
{
    class Program
    {
        private static bool isAdmin = false;

        static void Main()
        {
           
            //IDatabase db = new InMemoryDatabase();
            IDatabase db = new DiscountsMongoDB();
            ProductsBusinessLogic productsBll = new ProductsBusinessLogic(db);
            BrandsBusinessLogic brandsBll = new BrandsBusinessLogic(db);
            SellersBusinessLogic sellersBll = new SellersBusinessLogic(db);

            while (true)
            {
                string options = $"Options:" +
                    $"\n\t-Products\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Price|Name] [Asc|Desc]]" +
                    $"\n\t\t[-PriceRange [MinPrice, MaxPrice]]\n\t\t[-PriceGreaterThan [double]]" +
                    $"\n\t\t[-PriceLesserThan [double]]" +
                    $"\n\t-Brands\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Name] [Asc|Desc]]" +
                    $"\n\t-Sellers\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Name] [Asc|Desc]]" +
                    $"{(isAdmin ? "\n\t-Add [Name Price Brand Seller]\n\t-Logout" : "\n\t-Login")}" +
                    $"{(isAdmin ? "\n\t-Delete [Name Price Brand Seller]\n\t-Logout" : "")}" +
                    $"\n\t-Help" +
                    $"\n\t Press Ctrl+C to exit";
                Console.WriteLine(options);
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
                        Console.WriteLine("");
                        break;
                    case "-LOGIN":
                        Console.WriteLine("Please Write your password psst it is 1234");
                        var read = Console.ReadLine().ToUpper();
                        if (read == "1234") isAdmin = true;
                        break;
                    case "-LOGOUT":
                        if (isAdmin) isAdmin = false; else goto default;
                        break;
                    case "-ADD":
                        if (isAdmin) productsBll.Add(args); else goto default;
                        break;
                    case "-DELETE":
                        if (isAdmin) productsBll.Delete(args); else goto default;
                        break;
                    default:
                        Console.WriteLine($"Invalid args {arg}");
                        break;
                }

            }
        }

        private static void adminLayer()
        {
            isAdmin = true;
        }

       
            
    }
}
