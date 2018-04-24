using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(printHelloWorld);
            thread.Start();
            thread.Join();
            Console.ReadKey();
        }

        static void printHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
