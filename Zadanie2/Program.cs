using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>(10);
            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(PrintSomething));
            }

            while (true)
            {
                String msg = Console.ReadLine();
                String[] options = msg?.Split(' ');
                if (options[0].ToLower() == "start")
                {
                    if (options[1].Length < 2)
                    {
                        if (!threads[Int32.Parse(options[1])].IsAlive)
                        {
                            threads[Int32.Parse(options[1])].Start(Int32.Parse(options[1]));
                        }
                        else
                        {
                            threads[Int32.Parse(options[1])].Resume();
                        }
                    }
                    else
                    {
                        for (int i = Int32.Parse(options[1].ToCharArray()[0].ToString()); i <= Int32.Parse(options[1].ToCharArray()[2].ToString()); i++)
                        {
                            if (!threads[i].IsAlive)
                            {
                                threads[i].Start(i);
                            }
                            else
                            {
                                threads[i].Resume();
                            }
                        }
                    }
                }
                else if(options[0].ToLower() == "stop")
                {
                    if (options[1].Length < 2)
                    {
                        if(threads[Int32.Parse(options[1])].IsAlive) threads[Int32.Parse(options[1])].Suspend();
                    }
                    else
                    {
                        for (int i = Int32.Parse(options[1].ToCharArray()[0].ToString()); i <= Int32.Parse(options[1].ToCharArray()[2].ToString()); i++)
                        {
                            if (threads[Int32.Parse(options[1])].IsAlive) threads[i].Suspend();
                        }
                    }
                }
            }

            Console.ReadKey();
        }

        static void PrintSomething(object num)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 0; i < alpha.Length; i++)
            {
                Console.WriteLine($"{alpha[i]}{(int)num}");
                Thread.Sleep(1000);
            }
        }
    }
}
