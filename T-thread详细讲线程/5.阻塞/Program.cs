using System.Threading;
using System;

namespace _5.阻塞
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            // 判断阻塞状态必须进行 【按位与】才能判断他的值
            // 即，用线程的状态值(t.ThreadState)与 ThreadState.WaitSleepJoin 做【按位与】运算，
            // 如果结果不为 0，则说明线程处于阻塞状态
            bool blocked = (t.ThreadState & ThreadState.WaitSleepJoin) != 0;

            var state = ThreadState.Unstarted | ThreadState.Stopped | ThreadState.WaitSleepJoin;
            System.Console.WriteLine($"{Convert.ToString((int)ThreadState.Unstarted, 2)}");
            System.Console.WriteLine($"{Convert.ToString((int)ThreadState.Stopped, 2)}");
            System.Console.WriteLine($"{Convert.ToString((int)ThreadState.WaitSleepJoin, 2)}");

            System.Console.WriteLine($"{Convert.ToString((int)state, 2)}");
            System.Console.WriteLine($"{Convert.ToString((int)state)}");
            Console.ReadKey();
        }

        private static void ThreadMethod()
        {
            throw new NotImplementedException();
        }
    }
}
