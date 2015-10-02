using UnitOfWork;
using UnitOfWork.Test;
using UOW.Web.DataModel1;
using UOW.Web.DataModel2;
using UOW.Web.Service;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UOW.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(UOW.Web.App_Start.NinjectWebCommon), "Stop")]

namespace UOW.Web.App_Start
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Ninject;
	using Ninject.Web.Common;

	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<IUnitOfWorkTest<NoTime>>().To<UnitOfWorkTest<NoTime>>().InRequestScope();
			kernel.Bind<IUnitOfWorkTest<X4fleet>>().To<UnitOfWorkTest<X4fleet>>().InRequestScope();

			kernel.Bind<IRepositoryTest<Account, X4fleet>>().To<BaseRepositoryTest<Account, X4fleet>>().InRequestScope();
			kernel.Bind<IRepositoryTest<ERP_Contacts, NoTime>>().To<BaseRepositoryTest<ERP_Contacts, NoTime>>().InRequestScope();

			kernel.Bind<IManageAccountsAndContacts>().To<ManageAccountsAndContacts>().InRequestScope();
		}
	}
}
