using System;
using System.Data.Entity;

namespace UnitOfWork.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		DbContext Context { get; }
		void Commit();
	}
}
