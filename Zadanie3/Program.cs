﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        protected static char[] Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        static void Main(string[] args)
        {
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
            int lenght;
            lock (Alpha)
            {
                lenght = Alpha.Length;
            }

            for (int i = 0; i < lenght; i++)
            {
                lock (Alpha)
                {
                    Console.WriteLine($"{Alpha[i]}{(int)num}");
                    Thread.Sleep(10);
                }
            }
        }

    }
}