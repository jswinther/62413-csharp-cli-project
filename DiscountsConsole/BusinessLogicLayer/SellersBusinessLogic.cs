using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using System;
using System.Collections.Generic;
using DiscountsConsole.Models;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class SellersBusinessLogic : IBusinessLogic<Seller>
    {
        SellerDAL DAL;
        public SellersBusinessLogic(IDatabase db)
        {
            DAL = new SellerDAL(db.Sellers);

        }

        public List<Seller> PriceLessThan(List<Seller> entities, Stack<string> args)
        {
            throw new NotImplementedException();
        }

        public List<Seller> PriceRange(List<Seller> entities, Stack<string> args)
        {
            throw new NotImplementedException();
        }

        public List<Seller> PricerGreaterThan(List<Seller> entities, Stack<string> args)
        {
            throw new NotImplementedException();
        }

        public void Run(Stack<string> args)
        {
            throw new NotImplementedException();
        }

        public List<Seller> Search(List<Seller> entities, Stack<string> args)
        {
            throw new NotImplementedException();
        }

        public List<Seller> Sort(List<Seller> entities, Stack<string> args)
        {
            throw new NotImplementedException();
        }
    }
}