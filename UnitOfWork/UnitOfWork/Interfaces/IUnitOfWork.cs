using System;
using System.Data.Entity;

namespace UnitOfWork.UnitOfWork.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		DbContext Context { get; }

		T CastedContext<T>()
			where T : class;

		void Commit();
	}

	public interface IUnitOfWork<TContextType> : IDisposable
		where TContextType : DbContext
	{
		TContextType Context { get; }

		void Commit();
	}
}
