using System;
using System.Threading;

namespace CurrentThread的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread...";
            Thread t = new Thread(new ThreadStart(WriteY));//创建一个线程
            t.Name = "WriteY Thread...";
            t.Start();

            System.Console.WriteLine(Thread.CurrentThread.Name);
            // 同时主线程也在做一些工作
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }
            Console.ReadKey();
        }
        static void WriteY()
        {
            System.Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
                // Thread.Sleep(0);
            }
        }
    }
}
