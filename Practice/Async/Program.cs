//Taken from Yaniv's GitHub: https://github.com/yanivn2000/Sela_C_Sharp/blob/base/asyncWait1/Program.cs
using System;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            //In this example, we are going to take two methods, which are not dependent on each other.
            //Method1 is asynchronous and starts a new Thread so Method2 will start without wating to Method1 to end on the main Thread
            Method1();
            Method2();
            //Console.ReadKey();

            Run();
        }

        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(" Method 1");
                }
            });
        }

        async static void Run()
        {
            Task<int>[] array = new Task<int>[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = Process(i);
            }
            int[] values = await Task.WhenAll(array);

            foreach (var item in values)
            {
                Console.WriteLine($"Value: {item}");
            }
        }
        async static Task<int> Process(int test)
        {
            await Task.Run(() =>
            {
                test += 5;
            });
            return test;
        }

        public static void Method2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(" Method 2*************");
            }
        }
    }
}