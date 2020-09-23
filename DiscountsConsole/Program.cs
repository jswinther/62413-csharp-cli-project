using System;
using DiscountsConsole.Data;
using System.Linq;
using DiscountsConsole.BLL;
using System.Collections.Generic;
using DiscountsConsole.Models;

namespace DiscountsConsole
{
    class Program
    {
        static void Main()
        {
            IDatabase db = new InMemoryDatabase();

            ProductsBLL productsBll = new ProductsBLL(db);
            BrandsBLL brandsBll = new BrandsBLL(db);
            SellerBLL sellerBLL = new SellerBLL(db);

            
            var input = Console.ReadLine().Split(' ');
            Array.Reverse(input);
            Stack<string> args = new Stack<string>(input);

            


            while (args.Count > 0)
            {
                switch (args.Pop())
                {
                    case "-products":
                        var a = productsBll.Sort(args.Pop(), out int myNumber, out string myString);
                        foreach (var item in a)
                        {
                            Console.WriteLine(item.Display());
                        }
                        break;
                    case "-brands":
                        break;
                    case "-sellers":
                        break;
                    default:
                        break;
                }
            }

            

            Console.WriteLine(string.Join(' ', db.Products.Select(product => product.Seller).ToHashSet()));

        }
    }
}
