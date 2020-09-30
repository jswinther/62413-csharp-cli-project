using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using System;
using System.Collections.Generic;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class BrandsBusinessLogic : IBusinessLogic
    {
        BrandsDAL DAL;
        public BrandsBusinessLogic(IDatabase db)
        {
            DAL = new BrandsDAL(db.Brands);
        }

        public void Run(Stack<string> args)
        {



            Console.WriteLine();
        }

        


    }
}