using System;
using NServiceBus;

namespace BusStop.Billing.InternalMessages
{
    public class ChargeCreditCard :IMessage
    {
        public Guid CustomerId { get; set; }
        public double Amount { get; set; }
    }
}
