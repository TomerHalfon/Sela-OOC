using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterEvent
{
    // Student--- Create a class that Deries from EventArgs
    //   This class should keep the information we want to report when
    //   the event (tick changed) happens: Keep the counter value.
    //CounterEventArgs

    // Student --- Add a delegate definition to show the clients how
    // their reponse methods should look like (output: void, input: the counter, 
    //  and the EventArgs derived class above.
    public delegate void CounterHandler(Counter counter, CounterEventArgs e);

    public class Counter
    {
        // Students --- Add an event member so that clients could register
        //  on it. The event member type is of the delegate defined above.
        public event CounterHandler OnCounterEvent;

        public Counter(int startVal = 0) { CountedValue = startVal; }
        public int CountedValue { get; private set; }
        public void tickUp()
        {
            CountedValue++;
            OnTick();
        }
        public void tickDown()
        {
            CountedValue--;
            OnTick();
        }
        private void OnTick()
        {
            // Student --- Add code to :
            // 1. Check if clients are registered (if not - return)
            if (OnCounterEvent == null) return;
            // 2. Create EventArg information: what is the counted value
            CounterEventArgs counterEventArgs = new CounterEventArgs(CountedValue);
            // 3. Report the event to the registered clients, with the
            //    call to Invoke the clients response, where the sender 
            //     is the counter, and the EventArgs is the one you prepared above
            OnCounterEvent.Invoke(this, counterEventArgs);
        }

    }
}
