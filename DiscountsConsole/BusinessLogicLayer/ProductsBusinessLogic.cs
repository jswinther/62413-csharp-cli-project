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
            Console.WriteLine(DAL.Get().PriceRange(5, 10).SearchByName("Sød").SortByPrice().Print());
        }
    }
}
