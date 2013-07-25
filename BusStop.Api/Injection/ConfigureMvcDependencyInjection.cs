using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
//using System.Web.Http;
using System.Web.Http;
using System.Web.Mvc;
using NServiceBus;

namespace BusStop.Api.Injection
{
    public static class ConfigureMvcDependencyInjection
    {
        public static Configure ForWebApi(this Configure configure)
        {
            //Register controller activator with NSB
            configure.Configurer.RegisterSingleton(typeof (IControllerActivator),
                new NServiceBusControllerActivator());

            //Get controllers
            IEnumerable<Type> controllerTypes = Configure.TypesToScan
                .Where(t => typeof (ApiController).IsAssignableFrom(t));

            //Register controllers with the NSB container
            foreach (Type controllerType in controllerTypes)
                configure.Configurer.ConfigureComponent(controllerType, DependencyLifecycle.InstancePerCall);

            //Set  the MVC dependency resolver to use ours 

            GlobalConfiguration.Configuration.DependencyResolver =
                new NServiceBusDependencyResolverAdapter(configure.Builder);

            return configure;
        }

    }
}