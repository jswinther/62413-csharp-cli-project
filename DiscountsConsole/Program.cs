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
            string loginOptions = $"Welcome, please select login method by typing either:" +
             $"\n\t-User " +
             $"\n\t-Admin " +
             $"\n\t Press Ctrl+C to exit";
            while (true)
            {
                Console.WriteLine(loginOptions);
                var input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "-USER":
                        userLayer();
                        break;
                    case "-ADMIN":
                        Console.WriteLine("Please Write your password");
                        input = Console.ReadLine().ToUpper();
                        if(input == "1234")
                        {
                            adminLayer();
                        }
                        break;
                    default:
                        Console.WriteLine($"Invalid args {input}");
                        break;
                }
            }
        }

        private static void adminLayer()
        {
            Console.WriteLine("Yo wutup it's ya boy admingold");
        }

        private static void userLayer ()
        {
            bool userLoggedIn = true;

            string options = $"Options:" +
                $"\n\t-Products\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Price|Name] [Asc|Desc]]" +
                $"\n\t\t[-PriceRange [MinPrice, MaxPrice]]\n\t\t[-PriceGreaterThan [double]]" +
                $"\n\t\t[-PriceLesserThan [double]]" +
                $"\n\t-Brands\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Name] [Asc|Desc]]" +
                $"\n\t-Sellers\n\t\t[-NameSearch \"\\w+\"]\n\t\t[-Sort [Name] [Asc|Desc]]" +
                $"\n\t-Admin\n\t\t[-Add Product [params]]" +
                $"\n\t-Help" +
                $"\n\t-Logout" +
                $"\n\t Press Ctrl+C to exit";
            Console.WriteLine(options);

            //IDatabase db = new InMemoryDatabase();
            var db = new DiscountsMongoDB();

            ProductsBusinessLogic productsBll = new ProductsBusinessLogic(new ProductsDAL(db.Products));
            BusinessLogicProducts<Brand> brandsBll = new BusinessLogicProducts<Brand>(new BrandsDAL(db.Brands));
            BusinessLogicProducts<Seller> sellersBll = new BusinessLogicProducts<Seller>(new SellerDAL(db.Sellers));

            while(userLoggedIn)
            {
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
                    case "-LOGOUT":
                        userLoggedIn = false;
                        break;
                    default:
                        Console.WriteLine($"Invalid args {arg}");
                        break;
                }
            }
        }
            
    }
}
