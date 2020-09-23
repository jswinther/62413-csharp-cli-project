using DiscountsConsole.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountsConsole.BLL
{
    public class ProductsBLL
    {
        ProductsDAL DAL = new ProductsDAL();
        public void GetProductsBySeller()
        {
            var sellers = DAL.Get().Select(product => product.Seller).ToHashSet();
            foreach (var seller in sellers)
            {
                Console.WriteLine(seller);
               

                Console.WriteLine(string.Join('\n', DAL.Get().Where(product => product.Seller == seller)));
            }
            
        }
    }
}
