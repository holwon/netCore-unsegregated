using System.Threading.Tasks;
using System;

namespace TResult_Task的返回值
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                System.Console.WriteLine("Task.Running");
                return 42;
            });
            int result = t.Result;
            System.Console.WriteLine(result);// 如果 t 还没有完成，则会一直阻塞，直到 t 完成。
            System.Console.ReadKey();
        }
    }
}
