using BusStop.Sales.InternalMessages;
using NServiceBus;

namespace BusStop.Sales
{
    public class CancelOrderHandler : IHandleMessages<CancelOrder>
    {
        public IBus Bus { get; set; } 

        public void Handle(CancelOrder message)
        {
            //do work

            Bus.Return(CommandStatus.Success);
        }
    }
}
