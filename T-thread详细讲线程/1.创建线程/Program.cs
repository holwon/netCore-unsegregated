using System;
using System.Threading;

namespace 创建线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(WriteY));
            t.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }
            Console.ReadKey();
        }
        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
                // Thread.Sleep(0);
            }
        }
    }
}
