using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class ProductsBusinessLogic : IBusinessLogic
    {
        ProductsDAL DAL;
        public ProductsBusinessLogic(IDatabase db)
        {
            DAL = new ProductsDAL(db.Products);

        }

        public void Run(Stack<string> args)
        {
            Console.WriteLine(args.Count);
            Console.WriteLine(string.Join(' ', args));
            List<Product> products = DAL.Get();
            while (args.Count > 0)
            {
                var flag = args.Pop().ToUpper();
                var arg = args.Pop().ToUpper();
                switch (flag)
                {
                    case "-SORT":
                        if (arg.Equals("NAME")) products = products.SortByName();
                        else if(arg.Equals("PRICE")) products = products.SortByPrice();
                        else throw new Exception("Invalid sorting parameter");
                        break;
                    case "-NAMESEARCH":
                        products = products.SearchByName(arg);
                        break;
                    case "-PRICERANGE":
                        var maxprice = int.Parse(args.Pop());
                        products = products.PriceRange(int.Parse(arg), maxprice);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(products.Print()); 
            //Console.WriteLine(DAL.Get().PriceRange(5, 10).SearchByName("Sød").SortByPrice().Print());
        }
    }
}
