using System;
using BusStop.Sales.Contracts;
using BusStop.Sales.InternalMessages;
using NServiceBus;
using Raven.Client;

namespace BusStop.Sales
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IDocumentSession Session { get; set; }
        public IBus Bus { get; set; }

        public void Handle(PlaceOrder message)
        {
            Session.Store(new Order
            {
                OrderId = message.OrderId
            });

            Bus.Publish(new OrderAccepted()
            {
                CustomerId = message.CustomerId,
                OrderId = message.OrderId
            });
            //Bus.Send(new ChargeCreditCard
            //{
            //    CustomerId = message.CustomerId,
            //    Amount = 100
            //});

            Console.WriteLine("Order received: " + message.OrderId);
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
        
    }
}
