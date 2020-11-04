using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountsConsole.Data
{
    public interface IDatabaseCollection<T>
    {
        public void Add(T t);
        public List<T> Get();
    }
}
