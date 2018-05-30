using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Charger.Domm.Abstract;
using Charger.Domm.Concrete;
using Charger.WebUI.Infrastructure.Abstract;
using Charger.WebUI.Infrastructure.Concrete;
using Ninject;

namespace Charger.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IOperationsRepository>().To<EFOperationsRepository>();
            kernel.Bind<IApiRepository>().To<ApiRepository>();
            kernel.Bind<IAuthProv>().To<AuthProvider>();
        }
    }
}