using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   abstract class Animal
    {
        protected int age;

        public abstract void TakeBreath();

        public void Talk()
        {
            Console.WriteLine("Talking");
        }
        
    }
}
