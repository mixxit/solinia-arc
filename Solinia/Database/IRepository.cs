using System.Collections.Generic;

namespace Solinia.Database
{
    internal interface IRepository<T, TEntity>
    {
        T First();
        T Get(long Id);
        T Set(T entity);
        IEnumerable<long> Ids { get; }
    }
}