using System;
using System.Threading;

namespace _7.信号
{
    class Program
    {
        static void Main(string[] args)
        {
            var singal = new ManualResetEvent(false);
            new Thread(() =>
            {
                using (singal)
                {
                    Console.WriteLine("等待信号");
                    singal.WaitOne();
                    Console.WriteLine("收到信号");
                }
            })
            { IsBackground = true }.Start();// 后台线程

            Thread.Sleep(1000);
            Console.WriteLine("发送信号");
            singal.Set();// 发送信号
        }
    }
}
