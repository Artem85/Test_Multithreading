using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Synchronization_c
{
    class Program
    {
        static ConcurrentDictionary<int, string> dict = new ConcurrentDictionary<int, string>();

        static void Main(string[] args)
        {
            var thread1 = new Thread(Add5Elements)
            {
                Name = "Thread 1"
            };
            thread1.Start();

            var thread2 = new Thread(Add5Elements)
            {
                Name = "Thread 2"
            };
            thread2.Start();

            Thread.Sleep(1000);

            Console.WriteLine($"dict.Count = {dict.Count}");

            Console.ReadKey();
        }

        private static void Add5Elements()
        {
            for (int i = 0; i < 5; i++)
            {
                int key = Thread.CurrentThread.ManagedThreadId*100 + i;
                string item = Thread.CurrentThread.Name + $" item {i}";
                dict[key] = item;
                Console.WriteLine($"Add key:{key}, item:{item}");
            }
        }
    }
}
