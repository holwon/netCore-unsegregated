using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


// 将程序改成 Release 模式
namespace Volatile如果不用
{
    //将 volatile 修饰符添加到 _shouldStop 的声明后，
    //    将始终获得相同的结果（类似于前面代码中显示的片段）。 
    //    但是，如果 _shouldStop 成员上没有该修饰符，则行为是不可预测的。 
    //    DoWork 方法可能会优化成员访问，从而导致读取陈旧数据。
    //    鉴于多线程编程的性质，读取陈旧数据的次数是不可预测的。 
    //    不同的程序运行会产生一些不同的结果。
    public class Worker
    {
        private bool _shouldStop;
        //private volatile bool _shouldStop;

        public void DoWork()
        {
            bool work = false;
            // 注意：这里会被编译器优化为 while(true)
            while (!_shouldStop)
            {
                work = !work; // do sth.
            }
            Console.WriteLine("工作线程：正在终止...");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var worker = new Worker();

            Console.WriteLine("主线程：启动工作线程...");
            var workerTask = Task.Run(worker.DoWork);

            // 等待 500 毫秒以确保工作线程已在执行
            Thread.Sleep(500);

            Console.WriteLine("主线程：请求终止工作线程...");
            worker.RequestStop();

            // 待待工作线程执行结束
            workerTask.Wait();
            //workerThread.Join();

            Console.WriteLine("主线程：工作线程已终止");
            Console.ReadKey();
        }
    }
}
