using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterEvent
{
    public class Client
    {
        private Counter _server;
        public Client(Counter server)
        {
            _server = server;
            // Student--- Add registration code for the server counter event
        }
        // Student --- Add a method that responds to the event, the method
        // input and output should be the same as the delegate definition in the event


    }
}
