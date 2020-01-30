using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The main thread id is {Thread.CurrentThread.ManagedThreadId}");

            TestAsync();

            int a = 1;
            int b = 2;

            int c = Sum2Async(a, b).GetAwaiter().GetResult();
            Console.WriteLine($"{a} + {b} = {c}");

            Console.ReadKey();
        }

        static async void TestAsync()
        {
            Console.WriteLine($"The TestAsync thread id is {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => SumAsync());
        }

        static async void SumAsync()
        {
            Console.WriteLine($"The SumAsync thread id is {Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(() => Console.WriteLine($"1 + 2 = {1+2}"));
        }

        static async Task<int> Sum2Async(int a, int b)
        {
            return await Task.Run(() => a + b);
        }
    }
}
