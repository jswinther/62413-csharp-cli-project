using DiscountsConsole.DataAccessLayer;
using DiscountsConsole.Data;
using System;
using System.Collections.Generic;
using DiscountsConsole.Models;
using System.Linq;

namespace DiscountsConsole.BusinessLogicLayer
{
    public class BrandsBusinessLogic : AbstractProductsBusinessLogic<Brand>
    {
        public BrandsBusinessLogic(AbstractDAL<Brand> DAL) : base(DAL)
        {
        }
    }
}