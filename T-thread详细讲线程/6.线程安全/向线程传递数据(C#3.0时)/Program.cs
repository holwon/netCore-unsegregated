using System.Threading;
using System;

namespace 向线程传递数据_C_3._0时_
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Print));
            t.Start("Hello World");
        }

        private static void Print(object messageObj)
        {
            string message = Convert.ToString(messageObj);
            Console.WriteLine(message);
        }
    }
}
