using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Seafplus.BusinessLogic.UnitOfWork;

namespace Seafplus.BusinessLogic.Repository
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
	    internal DbSet<T> DbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
	        if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

	        DbSet = unitOfWork.Context.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Find(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public IList<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public IList<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetQueryable()
        {
            return DbSet;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public int Count()
        {
            return DbSet.Count();
        }
    }
}

