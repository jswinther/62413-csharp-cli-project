using DiscountsConsole.Models;
using System.Collections.Generic;

namespace DiscountsConsole.DataAccessLayer
{
    public interface IDataAccessLayer<T>
    {
        void Add(T entity);
        void Delete(T entity);
        List<T> Get();
    }
}