using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.MessageMutator;
using NServiceBus.Unicast.Transport;

namespace BusStop.Authentication
{
    public class AccessTokenPropogator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public IBus Bus { get; set; }

        public void MutateOutgoing(object[] messages, TransportMessage transportMessage)
        {
            if (Bus.CurrentMessageContext == null || !Bus.CurrentMessageContext.Headers.ContainsKey("access_token"))
                return;

            transportMessage.Headers["access_token"] = Bus.CurrentMessageContext.Headers["access_token"];
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<AccessTokenPropogator>(DependencyLifecycle.InstancePerCall);
        }
    }
}
