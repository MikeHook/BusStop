using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace BusStop.Authentication
{
    public class AuthenticationHandler : IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(IMessage message)
        {
			/* We get the idea, just allow all messages to be authenticated.
            var token = message.GetHeader("access_token");

            if (token != "busstop")
            {
                Console.WriteLine("User not authenticated");
                Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
                return;
            }
			 */ 

            Console.WriteLine("User authenticated");
        }
    }
}
