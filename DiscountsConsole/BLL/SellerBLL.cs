using DiscountsConsole.DAL;
using DiscountsConsole.Data;

namespace DiscountsConsole.BLL
{
    public class SellerBLL
    {
        SellerDAL DAL;
        public SellerBLL(IDatabase db)
        {
            DAL = new SellerDAL(db.Sellers);

        }
    }
}