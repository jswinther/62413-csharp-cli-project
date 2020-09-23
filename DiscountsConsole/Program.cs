using System;
using DiscountsConsole.Data;
using System.Linq;
using DiscountsConsole.BusinessLogicLayer;
using System.Collections.Generic;
using DiscountsConsole.Models;

namespace DiscountsConsole
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                IDatabase db = new InMemoryDatabase();
                ProductsBusinessLogic productsBll = new ProductsBusinessLogic(db);
                BrandsBusinessLogic brandsBll = new BrandsBusinessLogic(db);
                SellersBusinessLogic sellersBll = new SellersBusinessLogic(db);
                string options = $"Options:" +
                    $"\n\t-Products\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Price|Name]]" +
                    $"\n\t-Brands" +
                    $"\n\t-Sellers" +
                    $"\n\t-Help" +
                    $"\n\t Press Ctrl+C to exit";
                Console.WriteLine(options);
                var input = Console.ReadLine().Split(' ');
                Array.Reverse(input);
                Stack<string> args = new Stack<string>(input);
                switch (args.Pop().ToUpper())
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
                        break;
                }
            }
        }
    }
}
