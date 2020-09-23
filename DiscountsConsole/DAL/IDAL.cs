using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.DAL
{
    public interface IDAL<T>
    {
        void Add(T entity);
        void Delete(T entity);
        List<T> Get();
    }
}