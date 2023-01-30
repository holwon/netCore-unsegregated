using System.Diagnostics;
namespace 泛型
{
    public class Monitor
    {
        public static void ShowCompareRunTime()
        {
            System.Console.WriteLine("********** Monitor **********");
            int iValue = 123;
            long commonSecond = 0;
            long objectSecond = 0;
            long genericSecond = 0;

            // 对比执行时间

            // int类型
            {
                Stopwatch watch = new();
                watch.Start();
                // 执行3亿次
                for (var i = 0; i < 300_000_000; i++)
                {
                    ShowInt(iValue);
                }
                watch.Stop();
                commonSecond = watch.ElapsedMilliseconds;
                System.Console.WriteLine($"值类型所用时间: {commonSecond}");
            }
            // object类型
            {
                Stopwatch watch = new();
                watch.Start();
                // 执行3亿次
                for (var i = 0; i < 300_000_000; i++)
                {
                    objShow(iValue);
                }
                watch.Stop();
                objectSecond = watch.ElapsedMilliseconds;
                System.Console.WriteLine($"object(引用)所用时间: {objectSecond}");
            }
            // 泛型
            {
                Stopwatch watch = new();
                watch.Start();
                // 执行3亿次
                for (var i = 0; i < 300_000_000; i++)
                {
                    // Show<int>(iValue);
                    Show(iValue);// 泛型甚至可以不需要显示指定类型, 即添加尖括号, 鼠标移动到方法上面会显示推断出来的类型
                }
                watch.Stop();
                genericSecond = watch.ElapsedMilliseconds;
                System.Console.WriteLine($"泛型所用时间: {genericSecond}");
            }
        }

        private static void Show<T>(T iValue)
        {
            // do nothing
        }

        private static void objShow(object iValue)
        {
            // do nothing
        }

        private static void ShowInt(int iValue)
        {
            // do nothing
        }
    }
}