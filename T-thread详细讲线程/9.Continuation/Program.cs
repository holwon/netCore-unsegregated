using System;
using System.Linq;
using System.Threading.Tasks;

namespace _9.Continuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> primeNumberTask = Task.Run(() =>
            {
                // 返回一个数字，该数字表示指定序列中有多少元素满足条件。
                return Enumerable.Range(1, 5).Count(
                    // 判断是否是素数
                    x => Enumerable.Range(2, (int)Math.Sqrt(x) - 1).All(y => x % y != 0));
            });

            var awaiter = primeNumberTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine($"The number of prime numbers is {awaiter.GetResult()}");
            });

            System.Console.WriteLine("Prime numbers count: {0}", primeNumberTask.Result);

            Console.ReadKey();
        }
    }
}
