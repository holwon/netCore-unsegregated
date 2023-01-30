namespace 泛型
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Show(123);
            Monitor.ShowCompareRunTime();
            T.PrintArray(new List<int>() { 1, 2, 3 });
        }
        /// <summary>
        /// dotnet 2.0推出的新语法
        /// 
        /// 延迟声明: 把参数类型的声明延迟到调用
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        static void Show<T>(T value)
        {
            Console.WriteLine($"{typeof(Program)} + {value.GetType().Name}" + value.ToString());
        }

        static void objShow(object value)
        {
            Console.WriteLine($"{typeof(Program)} + {value.GetType().Name}" + value.ToString());
        }
    }
}