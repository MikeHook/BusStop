using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.MessageMutator;
using NServiceBus.Unicast.Transport;

namespace BusStop.Api.Authentication
{
    public class AccessTokenMutator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public void MutateOutgoing(object[] messages, TransportMessage transportMessage)
        {
            transportMessage.Headers["access_token"] = HttpContext.Current.Request.Params["access_token"];
            //transportMessage.SetHeader("access_token", HttpContext.Current.Request.Params["access_token"]);
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<AccessTokenMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
}