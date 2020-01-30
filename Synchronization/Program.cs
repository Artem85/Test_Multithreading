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

            for (int i = 0; i< 5; i++)
            {
                var thread1 = new Thread(() => Interlocked.Add(ref x, 1)); //x += 1
                thread1.Start();
                var thread2 = new Thread(() => Interlocked.Add(ref x, 2)); //x += 2
                thread2.Start();
            }

            Thread.Sleep(1000);
            Console.WriteLine($"x = {x}");
            //var thread1 = new Thread(Increase5TimesOn1);
            //var thread2 = new Thread(Increase5TimesOn2);

            //thread1.Start();
            //thread2.Start();

            Console.ReadKey();
        }

        //static void Increase5TimesOn1()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine($"Current Thread id is {Thread.CurrentThread.ManagedThreadId}");
        //        //Thread.Sleep(100);
        //        Interlocked.Add(ref x, 1);
        //        Console.WriteLine($"x = {x}");
        //    }
        //}

        //static void Increase5TimesOn2()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine($"Current Thread id is {Thread.CurrentThread.ManagedThreadId}");
        //        //Thread.Sleep(100);
        //        Interlocked.Add(ref x, 2);
        //        Console.WriteLine($"x = {x}");
        //    }
        //}
    }
}
