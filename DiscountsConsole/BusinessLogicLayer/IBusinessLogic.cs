using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.BusinessLogicLayer
{
    public interface IBusinessLogic<T>
    {
        List<T> PriceLessThan(List<T> entities, Stack<string> args);
        List<T> PriceRange(List<T> entities, Stack<string> args);
        List<T> PricerGreaterThan(List<T> entities, Stack<string> args);
        void Run(Stack<string> args);
        List<T> Search(List<T> entities, Stack<string> args);
        List<T> Sort(List<T> entities, Stack<string> args);
    }
}