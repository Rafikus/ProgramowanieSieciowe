using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie4
{
    class Program
    {
        protected static char[] _alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static Semaphore semaphore;
        static void Main(string[] args)
        {
            semaphore = new Semaphore(3, 3);
            List<Thread> threads = new List<Thread>(10);
            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(PrintSomething));
            }

            foreach (var thread in threads)
            {
                thread.Start(threads.IndexOf(thread));
            }

            Console.ReadKey();
        }

        static void PrintSomething(object num)
        {
            semaphore.WaitOne();
            for (int i = 0; i < _alpha.Length; i++)
            {
                lock (_alpha)
                {
                    Console.WriteLine($"{_alpha[i]}{(int)num}");
                    Thread.Sleep(10);
                }
            }

            semaphore.Release(1);
        }

    }
}

