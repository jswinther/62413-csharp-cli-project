using DiscountsConsole.Data;
using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.DataAccessLayer
{
    public class BrandsDAL : AbstractDAL<Brand>
    {
        public BrandsDAL(List<Brand> list) : base(list)
        {
        }
    }
}