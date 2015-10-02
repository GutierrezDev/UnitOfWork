using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWork
{
	public interface IRepositoryTest<TDbSetType, TContextType>
	{
		TDbSetType Get(Expression<Func<TDbSetType, bool>> predicate);
		TDbSetType FirstOrDefault(Expression<Func<TDbSetType, bool>> predicate);
		IList<TDbSetType> GetAll(Expression<Func<TDbSetType, bool>> predicate);
		IList<TDbSetType> GetAll();
		void Add(TDbSetType entity);
		void Delete(TDbSetType entity);
		IQueryable<TDbSetType> GetQueryable(Expression<Func<TDbSetType, bool>> predicate);
		IQueryable<TDbSetType> GetQueryable();
		int Count(Expression<Func<TDbSetType, bool>> predicate);
		int Count();
	}
}
