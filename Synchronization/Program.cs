using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization
{
    class Program
    {
        //static int x = 0;

        static void Main(string[] args)
        {
            int x = 0;

            var countdownEvent = new CountdownEvent(10);
            for (int i = 0; i < 5; i++)
            {
                ManualResetEvent event1 = new ManualResetEvent(false);
                var thread1 = new Thread(() =>
                {
                    Interlocked.Add(ref x, 1); //x += 1
                    countdownEvent.Signal();
                });
                thread1.Start();

                ManualResetEvent event2 = new ManualResetEvent(false);
                var thread2 = new Thread(() =>
                {
                    Interlocked.Add(ref x, 2); //x += 2
                    countdownEvent.Signal();
                });
                thread2.Start();
            }

            countdownEvent.Wait();
            Console.WriteLine($"x = {x}");

            Console.ReadKey();
        }
    }
}
