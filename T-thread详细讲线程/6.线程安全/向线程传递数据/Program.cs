using System.Threading;
using System;

namespace 向线程传递数据
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 整个逻辑写入线程
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                    Thread.Sleep(100);
                }
            }).Start();

            // 2. 创建线程，并传递数据
            // 注: 必须赋值给变量，否则会报错
            Thread t = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    PrintI(i);
                    Thread.Sleep(100);
                }
            });
            t.Start();
            Console.ReadKey();
        }
        static void PrintI(int i)
        {
            Console.WriteLine("Thread B: {0}", i);
        }
    }
}
