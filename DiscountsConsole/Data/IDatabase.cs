using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.Data
{
    public interface IDatabase : IDatabaseCollection<Product>, IDatabaseCollection<Seller>, IDatabaseCollection<Brand>
    {
        
    }
}