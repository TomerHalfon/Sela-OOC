using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterEvent
{
    public class CounterEventArgs : EventArgs
    {
        public int CounterValue { get; }
        public CounterEventArgs(int counterValue)
        {
            CounterValue = counterValue;
        }
    }
}
