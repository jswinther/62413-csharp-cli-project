using System.Collections.Generic;

namespace DiscountsConsole.Models
{
    public interface IProducts<T> where T : IPrice, IName
    {
        List<T> Products { get; set; }
    }
}