using System.Threading;
using System.Threading.Tasks;
using System;

namespace Task_Wait
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Task is running");
                Thread.Sleep(3000);
                Console.WriteLine("Task is finished");
            });
            System.Console.WriteLine("task status: " + task.Status);
            System.Console.WriteLine(task.IsCompleted);
            // System.Console.WriteLine(task.IsCompletedSuccessfully);

            task.Wait();// 阻塞主线程，等待任务完成

            System.Console.WriteLine("task status: " + task.Status);
            // System.Console.WriteLine(task.IsCompletedSuccessfully);
            System.Console.WriteLine(task.IsCompleted);

        }
    }
}
