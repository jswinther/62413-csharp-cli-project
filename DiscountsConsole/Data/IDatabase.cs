using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.Data
{
    public interface IDatabase
    {
        List<Brand> Brands { get; }
        List<Product> Products { get; }
        List<Seller> Sellers { get; }
    }
}