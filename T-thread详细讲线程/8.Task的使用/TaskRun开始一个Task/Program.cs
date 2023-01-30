using System;
using System.Threading.Tasks;

namespace TaskRun开始一个Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task运行的是后台线程，如果主线程/前台线程结束，Task也会自动结束
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Task Run: {0}", i);
                }
            });
            // 所以我们可以让主线程等待或者阻塞
            Console.ReadLine();// 这也相当于一种阻塞
        }
    }
}
