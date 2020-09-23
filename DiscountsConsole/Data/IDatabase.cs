using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.Data
{
    public interface IDatabase
    {
        List<Brand> Brands { get; set; }
        List<Product> Products { get; set; }
        List<Seller> Sellers { get; set; }
    }
}