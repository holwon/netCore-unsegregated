using System.Threading;
using System;

namespace 新建文件夹
{
    class Program
    {
        // 静态字段被同一个应用域下的所有线程共享
        static bool _done1;
        static void Main(string[] args)
        {
            ThreadStart action = () =>
            {
                if (!_done1)
                {
                    _done1 = true;
                    Console.WriteLine("Done1");
                }
            };
            new Thread(action).Start();
            action();


            // 变量被lambda表达式捕获，会转化为类的一个field,
            // 所以也能被线程共享
            bool _done2 = false;
            ThreadStart action2 = () =>
            {
                if (!_done2)
                {
                    _done2 = true;
                    Console.WriteLine("Done2");
                }
            };
            new Thread(action2).Start();
            action2();

            Console.ReadKey();
        }
    }
}
