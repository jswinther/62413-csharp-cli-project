using System.Collections.Generic;

namespace DiscountsConsole.Models
{
    public interface IProducts
    {
        List<Product> Products { get; set; }
    }
}