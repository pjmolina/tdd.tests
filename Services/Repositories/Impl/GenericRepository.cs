using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Unir.Aggregates;

namespace Unir.Repositories.Impl
{

    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public T Add(T elem)
        {
            return _context.Set<T>().Add(elem).Entity;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetFiltered(Expression<Func<T, bool>> expr)
        {
            return _context.Set<T>().Where(expr).ToList();
        }

        public void Remove(T elem)
        {
            _context.Set<T>().Remove(elem);
        }
    }

}