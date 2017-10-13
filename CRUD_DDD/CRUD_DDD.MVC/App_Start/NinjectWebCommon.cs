[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CRUD_DDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CRUD_DDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace CRUD_DDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Infra.Repositories;
    using CRUD_DDD.Domain.Contracts.Repositories;
    using CRUD_DDD.Services;
    using CRUD_DDD.Services.Customers;

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
            //O transaction n�o � utilizado por inje��o, pois ele est� encapsulado com o context, mas � uma op��o tamb�m.
            kernel.Bind<ITransaction>().To<Transaction>();
            //--------------------------//

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind(typeof(ITransaction)).To<Transaction>();
            kernel.Bind(typeof(IServiceBase<,,,>)).To(typeof(ServiceBase<,,,,>));
            kernel.Bind<ICustomerService>().To<CustomerService>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
        }
    }
}
