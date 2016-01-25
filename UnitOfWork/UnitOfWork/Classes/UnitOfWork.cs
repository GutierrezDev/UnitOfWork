using System;
using System.Data.Entity;
using UnitOfWork.Attributes;
using UnitOfWork.Interfaces;
using UnitOfWork.UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork.Classes
{
    [InterfaceInjection]
	public class UnitOfWork : IUnitOfWork
	{
        private bool _isDisposed;

		public UnitOfWork(DbContext context)
		{
			Context = context;
		}

		public DbContext Context { get; }

        public T CastedContext<T>()
			where T : class 
        {
			if (!(Context is T))
			{
				throw new InvalidCastException();
			}

			return Context as T;
		}

		public void Commit()
		{
			Context.SaveChanges();
		}

		public void Dispose()
		{
		    if (_isDisposed)
		    {
		        return;
		    }

		    if (Context == null)
		    {
		        return;
		    }

		    Context.Dispose();
		    _isDisposed = true;
		}
	}

    [InterfaceInjection]
	public class UnitOfWork<TContextType> : IUnitOfWork<TContextType>
		where TContextType : DbContext
	{
        private bool _isDisposed;

        public UnitOfWork(TContextType context)
		{
			Context = context;
		}

		public TContextType Context { get; }

        public void Commit()
		{
			Context.SaveChanges();
		}

		public void Dispose()
		{
		    if (_isDisposed)
		    {
		        return;
		    }

		    if (Context == null)
		    {
		        return;
		    }

		    Context.Dispose();
		    _isDisposed = true;
		}
	}
}
