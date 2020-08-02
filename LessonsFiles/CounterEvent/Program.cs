using System;

namespace CounterEvent
{
    class Program
    {
        static void Main()
        {

            Counter c1 = new Counter();

            Client a1 = new Client(c1); // creating a new client with c1 as server



            c1.tickUp();
            c1.tickUp();
            c1.tickDown();
            
            

        }
    }
}
//