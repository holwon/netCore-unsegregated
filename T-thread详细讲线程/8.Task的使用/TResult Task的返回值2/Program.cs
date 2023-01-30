using System.Linq;
using System;
using System.Threading.Tasks;

namespace TResult_Task的返回值2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Task的使用
            // 代码的实验
            Task<int> primeNumberTask = Task.Run(() =>
            {
                int count = 0;
                System.Console.WriteLine("Task is running on a thread from thread pool.");
                // 返回一个数字，该数字表示指定序列中有多少元素满足条件。
                count = Enumerable.Range(1, 3000000).Count(
                    // 判断是否是素数
                    x => Enumerable.Range(2, (int)Math.Sqrt(x) - 1).All(y => x % y != 0));
                System.Console.WriteLine("Prime numbers count: {0}", count);
                return count;
            });
            System.Console.WriteLine("Task is running...");
            // 在这里，我们可以接收Task的返回值。
            // 接收Task的返回值会等待Task完成，然后返回Task的返回值。即，会导致主线程阻塞。
            System.Console.WriteLine("Prime numbers count: {0}", primeNumberTask.Result);
            #endregion

            #region Enumerable的使用
            System.Console.WriteLine(Enumerable.Range(0, 2).Count());

            System.Console.WriteLine(
                Enumerable.Range(1, 1000000).Count(// Count 返回一个数字，该数字表示指定序列中有多少元素满足条件。    
                    Enumerable.Range(1, 100).Contains));// Contains就是会去查找是否包含这个值
            #endregion
            /* ---------------------------------------------------- */

            Console.ReadKey();
        }
    }
}
