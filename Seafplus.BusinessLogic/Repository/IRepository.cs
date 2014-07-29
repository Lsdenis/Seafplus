using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Seafplus.BusinessLogic.Repository
{
    public interface IRepository<T>
    {       
        T Get(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        IList<T> GetAll(Expression<Func<T, bool>> predicate);
        IList<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable();
        int Count(Expression<Func<T, bool>> predicate);
        int Count();
    }
}
