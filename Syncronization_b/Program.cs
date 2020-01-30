using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization_b
{
    class Program
    {
        static List<int> col = new List<int>();
        static object locker = new object();

        static void Main(string[] args)
        {
            var thread1 = new Thread(Add5Elements);
            thread1.Start();
            var thread2 = new Thread(Add5Elements);
            thread2.Start();

            Thread.Sleep(1000);

            Console.WriteLine($"col.Count = {col.Count}");

            Console.ReadKey();
        }

        private static void Add5Elements()
        {
            try
            {
                Monitor.Enter(locker);

                for (int i = 0; i < 5; i++)
                {
                    int item = Thread.CurrentThread.ManagedThreadId + i;
                    col.Add(item);
                    Console.WriteLine($"Add item {item}");
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
    }
}
