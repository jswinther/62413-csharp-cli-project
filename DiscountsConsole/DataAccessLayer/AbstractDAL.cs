using DiscountsConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.DataAccessLayer
{
    public abstract class AbstractDAL<T> : IDataAccessLayer<T> where T : IName
    {
        private List<T> List;

        protected AbstractDAL(List<T> list)
        {
            List = list ?? throw new ArgumentNullException(nameof(list));
        }

        public void Add(T entity)
        {
            List.Add(entity);
        }

        public void Delete(T entity)
        {

            List.Remove(entity);
        }

        public List<T> Get()
        {
            
            return List;
        }
    }
}
