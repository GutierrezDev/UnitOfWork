using System;
using System.Data.Entity;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Test
{
	public class UnitOfWork<TContextType> : IUnitOfWorkTest<TContextType>, IDependency
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

		public TContextType GetContext
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
