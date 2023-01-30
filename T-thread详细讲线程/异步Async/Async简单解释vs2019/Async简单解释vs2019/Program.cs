using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Async简单解释vs2019
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("· 1\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
            var client = new HttpClient();
            System.Console.WriteLine("· 2\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
            var response = client.GetStringAsync("http://www.google.com");
            System.Console.WriteLine("· 3\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
            var a = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                a += i;
            }
            System.Console.WriteLine("· 4\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
            var page = await response;
            System.Console.WriteLine("· 5\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);

            Console.ReadLine();
        }

    }
}
