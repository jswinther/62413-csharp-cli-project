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
            IDatabase db = new InMemoryDatabase();
            ProductsBusinessLogic productsBll = new ProductsBusinessLogic(db);
            BrandsBusinessLogic brandsBll = new BrandsBusinessLogic(db);
            SellersBusinessLogic sellersBll = new SellersBusinessLogic(db);
            var input = Console.ReadLine().Split(' ');
            Array.Reverse(input);
            Stack<string> args = new Stack<string>(input);
            switch (args.Pop())
            {
                case "-products":
                    productsBll.Run(args);
                    break;
                case "-brands":
                    brandsBll.Run(args);
                    break;
                case "-sellers":
                    sellersBll.Run(args);
                    break;
                default:
                    break;
            }
        }
    }
}
