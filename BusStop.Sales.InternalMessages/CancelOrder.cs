using System;
using NServiceBus;

namespace BusStop.Sales.InternalMessages
{
    //[TimeToBeReceived("00:00:10")]
    public class CancelOrder : IMessage
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }
    }
}