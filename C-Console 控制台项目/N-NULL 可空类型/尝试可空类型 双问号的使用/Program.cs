using System.Threading.Tasks.Dataflow;
using System;

namespace 尝试可空类型
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //类型名称后面带? 即是可空类型            
            int? a = null;//int？：表示可空类型，就是一种特殊的值类型，它的值可以为null

            Console.WriteLine(a ?? 1);
            //int??：用于判断并赋值，先判断当前变量是否为null，如果是就可以赋役个新值，否则跳过
            string str = null;
            Console.WriteLine("str: " + (str ?? "我是null"));

            string s2 = "我不是null";
            Console.WriteLine($"s2{s2 ?? "我是null"}");

            string f() => "test f()";
            Func<string> f2 = f;
            dynamic t() => f2();

            Console.WriteLine(t() ?? "我是null");
        }
    }
}
