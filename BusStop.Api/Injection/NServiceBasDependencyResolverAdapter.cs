using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using NServiceBus;
using NServiceBus.ObjectBuilder;
using NServiceBus.Unicast;

namespace BusStop.Api.Injection
{
    public class NServiceBusDependencyResolverAdapter : IDependencyResolver
    {
        private readonly IBuilder _builder;

        public NServiceBusDependencyResolverAdapter(IBuilder builder)
        {
            _builder = builder;
        }

        public object GetService(Type serviceType)
        {
            if (Configure.Instance.Configurer.HasComponent(serviceType))
                return _builder.Build(serviceType);
            else
                return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _builder.BuildAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}