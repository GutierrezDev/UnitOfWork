using System;
using System.Data.Entity;
using UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork, IDependency
	{
		private readonly DbContext _context;

		public UnitOfWork(DbContext context)
		{
			_context = context;
		}

		public DbContext Context
		{
			get { return _context; }
		}

		public T GetContext<T>()
			where T : class
		{
			if (!(Context is T))
			{
				throw new NullReferenceException();
			}

			return Context as T;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
			}
		}
	}
}
