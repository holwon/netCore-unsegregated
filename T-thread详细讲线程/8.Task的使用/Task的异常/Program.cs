using System.Threading.Tasks;
using System;

namespace Task的异常
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                throw null;
            });
            try
            {
                task.Wait();// 异常会抛出给调用 Wait 的线程
            }
            catch (AggregateException aEx)
            {
                // foreach (var e in aEx.InnerExceptions)
                // {
                //     Console.WriteLine(e.Message);
                // }
                if (aEx.InnerException is NullReferenceException)
                {
                    Console.WriteLine("NullReferenceException");
                }
                else
                {
                    throw;
                }
            }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
        }
    }
}
