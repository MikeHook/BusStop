using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace BusStop.config
{
    public static class MyConventions
    {
        public static Configure MyMessageConventions(this Configure config)
        {
            config
                //Allows us to define where the events are kept, without them explicitly inheriting from IEvent
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Contracts"));

            return config;
        }
    }
}
