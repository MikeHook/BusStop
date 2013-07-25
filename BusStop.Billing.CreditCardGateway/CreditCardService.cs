using System;
using NServiceBus;
using NServiceBus.Config;

namespace BusStop.Billing.CreditCardGateway
{
    public class CreditCardService: ICreditCardService, INeedInitialization
    {
        public string Charge(Guid customerId, double amount)
        {
            Console.WriteLine("Customer " + customerId + " charged with: " + amount);
            return Guid.NewGuid().ToString();
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<CreditCardService>(
                DependencyLifecycle.InstancePerCall);
        }
    }
}