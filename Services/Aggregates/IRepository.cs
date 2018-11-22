using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Unir.Aggregates
{
    public interface IRepository<T>
        where T : class
    {
        T Get(int id);
        List<T> GetAll();
        List<T> GetFiltered(Expression<Func<T, bool>> expr);

        T Add(T elem);
        void Remove(T elem);

        void Commit();
    }
}