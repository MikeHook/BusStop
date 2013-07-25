using System.Web;
using BusStop.Sales.Contracts;
using BusStop.Sales.InternalMessages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusStop.Api.Controllers
{
    public class OrdersController : ApiController
    {
        public Guid Get()
        {
            var order = new PlaceOrder()
            {
                OrderId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid()
            };

            WebApiApplication.Bus.Send(order);

            return order.OrderId;
        }

    }
}
