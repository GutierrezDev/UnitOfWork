﻿using System;
using System.Data.Entity;

namespace UnitOfWork.UnitOfWork.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		DbContext Context { get; }

		T GetContext<T>()
			where T : class;

		void Commit();
	}

	public interface IUnitOfWork<TContextType> : IDisposable
		where TContextType : class
	{
		DbContext Context { get; }

		TContextType CastedContext { get; }

		void Commit();
	}
}