using System.Collections;
using OAuth2;
using Seafplus.BusinessLogic.DataModel;
using Seafplus.BusinessLogic.Repository;
using Seafplus.BusinessLogic.Services;
using Seafplus.BusinessLogic.Services.Interfaces;
using Seafplus.BusinessLogic.UnitOfWork;
using Seafplus.Helpers;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Seafplus.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Seafplus.App_Start.NinjectWebCommon), "Stop")]

namespace Seafplus.App_Start
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

		private static void InitStaticClasses(IKernel kernel)
	    {
			GlobalStoreHelper.Initialize(kernel.Get<IUserService>());
	    }

	    /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
	        kernel.Bind<EntityContainer>().ToSelf().InRequestScope();
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

			kernel.Bind<IUserService>().To<UserService>().InRequestScope();
			kernel.Bind<IBoardService>().To<BoardService>().InRequestScope();
			kernel.Bind<IListService>().To<ListService>().InRequestScope();

	        kernel.Bind<IRepository<User>>().To<BaseRepository<User>>().InRequestScope();
			kernel.Bind<IRepository<Board>>().To<BaseRepository<Board>>().InRequestScope();
			kernel.Bind<IRepository<UserBoard>>().To<BaseRepository<UserBoard>>().InRequestScope();
			kernel.Bind<IRepository<List>>().To<BaseRepository<List>>().InRequestScope();
			kernel.Bind<IRepository<Card>>().To<BaseRepository<Card>>().InRequestScope();

			kernel.Bind<AuthorizationRoot>().ToSelf().WithConstructorArgument("sectionName", "oauth2");

		    InitStaticClasses(kernel);
        }        
    }
}
