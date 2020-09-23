using DiscountsConsole.DAL;
using DiscountsConsole.Data;

namespace DiscountsConsole.BLL
{
    internal class BrandsBLL
    {
        BrandsDAL DAL;
        public BrandsBLL(IDatabase db)
        {
            DAL = new BrandsDAL(db.Brands);
        }


    }
}