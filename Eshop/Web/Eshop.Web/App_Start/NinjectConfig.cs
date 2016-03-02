using Eshop.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectConfig), "Stop")]

namespace Eshop.Web
{
    using System;
    using System.Web;
    using Data;
    using Data.Repositories;
    using GlobalConstants;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Infrastructure;
    public static class NinjectConfig
    {
        public static Action<IKernel> RegisterDependencies = kernel =>
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind(typeof(IEshopDbContext)).To(typeof(EshopDbContext)).InRequestScope();
        };

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
                ObjectFactory.InitializeKernel(kernel);
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
            RegisterDependencies(kernel);


            //kernel.Bind(typeof(IItemsService)).To(typeof(ItemsService));

            kernel.Bind(x => x
                .From(Assemblies.ServicesDataAssembly)
                .SelectAllClasses()
                .BindDefaultInterface());

            //kernel.Bind(x => x
            //    .From(Assemblies.ServicesWebAssembly)
            //    .SelectAllClasses()
            //    .BindDefaultInterface());
        }
    }
}
