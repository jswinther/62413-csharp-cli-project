using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using System;
using System.Collections.Generic;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class SellersBusinessLogic : IBusinessLogic
    {
        SellerDAL DAL;
        public SellersBusinessLogic(IDatabase db)
        {
            DAL = new SellerDAL(db.Sellers);

        }

        public void Run(Stack<string> args)
        {
            throw new NotImplementedException();
        }
    }
}