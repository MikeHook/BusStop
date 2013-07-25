using BusStop.Authentication;
using BusStop.config;

namespace BusStop.Backend 
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/profiles-for-nservicebus-host
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, ISpecifyMessageHandlerOrdering, IWantCustomInitialization
    {
	    public void SpecifyOrder(NServiceBus.Order order)
	    {
            order.Specify<First<AuthenticationHandler>>();
	    }

	    public void Init()
	    {
	        Configure.With().MyMessageConventions();
	    }
    }
}