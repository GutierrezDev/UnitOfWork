using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using UnitOfWork.Repository.Classes;
using UnitOfWork.Repository.Interfaces;
using UnitOfWork.UnitOfWork.Classes;
using UnitOfWork.UnitOfWork.Interfaces;
using UOW.Web.App_Start;
using UOW.Web.DataModel1;
using UOW.Web.DataModel2;
using UOW.Web.Service;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace UOW.Web.App_Start
{
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
			kernel.Bind<IUnitOfWork<NoTime>>().To<UnitOfWork<NoTime>>().InRequestScope();
			kernel.Bind<IUnitOfWork<X4fleet>>().To<UnitOfWork<X4fleet>>().InRequestScope();

			kernel.Bind<IRepository<Account, X4fleet>>().To<BaseRepository<Account, X4fleet>>().InRequestScope();
			kernel.Bind<IRepository<ERP_Contacts, NoTime>>().To<BaseRepository<ERP_Contacts, NoTime>>().InRequestScope();

			kernel.Bind<IManageAccountsAndContacts>().To<ManageAccountsAndContacts>().InRequestScope();
		}
	}
}
