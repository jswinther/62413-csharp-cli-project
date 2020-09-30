using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using System;
using System.Collections.Generic;
using DiscountsConsole.Models;
using System.Linq;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class SellersBusinessLogic : AbstractProductsBusinessLogic<Seller>
    {
        public SellersBusinessLogic(AbstractDAL<Seller> DAL) : base(DAL)
        {
        }
    }
}