using System;
using BusStop.Billing.InternalMessages;
using NServiceBus;

namespace BusStop.Billing
{
    public class CreditCardChargedHandler : IHandleMessages<CreditCardCharged>
    {
        public void Handle(CreditCardCharged message)
        {
            //todo store in raven
            Console.WriteLine("Customer " + message.CustomerId + " charged, receipt: " + message.Receipt);
        }
    }
}
