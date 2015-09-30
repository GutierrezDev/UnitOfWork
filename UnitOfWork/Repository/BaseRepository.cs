using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UnitOfWork.UnitOfWork;

namespace UnitOfWork.Repository
{
	public class BaseRepository<T> : IRepository<T>
		where T : class
	{
		private readonly DbSet<T> _dbSet;

		public BaseRepository(IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException("unitOfWork");
			}

			_dbSet = unitOfWork.Context.Set<T>();
		}

		public T Get(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Find(predicate);
		}

		public T FirstOrDefault(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.FirstOrDefault(predicate);
		}

		public IList<T> GetAll(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Where(predicate).ToList();
		}

		public IList<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Where(predicate);
		}

		public IQueryable<T> GetQueryable()
		{
			return _dbSet;
		}

		public int Count(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Count(predicate);
		}

		public int Count()
		{
			return _dbSet.Count();
		}
	}
}

