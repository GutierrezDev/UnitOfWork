using System;
using System.Data.Entity;

namespace UnitOfWork.Test
{
	public interface IUnitOfWorkTest<TContextType> : IDisposable
		where TContextType : class
	{
		DbContext Context { get; }

		TContextType GetContext { get; }

		void Commit();
	}
}
