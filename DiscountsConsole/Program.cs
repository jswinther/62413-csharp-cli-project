using System;
using DiscountsConsole.Data;
using System.Linq;
namespace DiscountsConsole
{
    class Program
    {
        static void Main()
        {
            string[] args = Console.ReadLine().Split(' ');
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }



            Database db = new Database();
            
            Console.WriteLine(string.Join(' ', db.Products.Select(product => product.Seller).ToHashSet()));

        }
    }
}
