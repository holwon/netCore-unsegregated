using System.Threading;
using System;

namespace _3.join方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(GO));
            t.Start();
            t.Join();// join方法会使主线程阻塞，直到t线程结束
            Console.WriteLine("Thread t has ended");
            System.Console.WriteLine();
            Console.WriteLine("Main thread");
            Console.ReadKey();
        }

        private static void GO()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
            }
        }
    }
}
