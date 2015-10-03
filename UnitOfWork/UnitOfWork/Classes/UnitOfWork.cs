using System;
using System.Data.Entity;
using UnitOfWork.Interfaces;
using UnitOfWork.UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork.Classes
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

	public class UnitOfWork<TContextType> : IUnitOfWork<TContextType>, IDependency
		where TContextType : class
	{
		private readonly DbContext _context;

		public UnitOfWork(TContextType context)
		{
			if (!typeof(TContextType).IsSubclassOf(typeof(DbContext)))
			{
				throw new InvalidCastException();
			}

			_context = context as DbContext;
		}

		public DbContext Context
		{
			get { return _context; }
		}

		public TContextType CastedContext
		{
			get
			{
				if (!(Context is TContextType))
				{
					throw new NullReferenceException();
				}

				return Context as TContextType;
			}
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
