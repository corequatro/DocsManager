[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DocsManagerWebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DocsManagerWebApp.App_Start.NinjectWebCommon), "Stop")]

namespace DocsManagerWebApp.App_Start
{
    using System;
    using System.Web;
    using DocsManager.Bll;
    using DocsManager.Bll.Implementation;
    using DocsManager.Dal.Repositories;
    using DocsManager.IDal;
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
                RegisterRepositories(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<HttpContextBase>().ToMethod(x => new HttpContextWrapper(HttpContext.Current));
            kernel.Bind<HttpContext>().ToMethod(ctx => HttpContext.Current).InTransientScope();
            kernel.Bind<IDocumentService>().To<DocumentService>().InRequestScope();
        }

        private static void RegisterRepositories(IKernel kernel)
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}
