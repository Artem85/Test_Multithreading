using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            int a = 1;
            int b = 2;

            Console.WriteLine($"The main thread id is {Thread.CurrentThread.ManagedThreadId}");

            Task task = new Task(() =>
            {
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"Current task thread id is {Thread.CurrentThread.ManagedThreadId}");
                Task.Delay(1000);

                Console.WriteLine($"{a} + {b} = {a + b}");
            }, token);

            cts.Cancel();

            try
            {
                task.Start();
            }
            catch { }

            Console.WriteLine($"Current task status is {task.Status}");

            Console.ReadKey();
        }
    }
}
