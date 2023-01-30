using System.Threading;
using System;

namespace 加锁
{
    class Program
    {
        static bool _done;
        // 此处使用 object 类型的对象,
        // 这一句话意思是，这个锁 lock(),可以基于任何 类型 的对象
        static object _lock = new object();
        static void Main(string[] args)
        {
            new Thread(Go).Start();
            Go();
            Console.ReadLine();
        }

        private static void Go()
        {
            lock (_lock)
            {
                if (!_done)
                {
                    Console.WriteLine("Done");
                    Thread.Sleep(100);
                    _done = true;
                }
            }
        }
    }
}
