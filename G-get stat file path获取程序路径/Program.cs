using System.Diagnostics;
using System.Reflection;

namespace testdir
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Launched from {Environment.CurrentDirectory}");
            Console.WriteLine($"Physical location {AppDomain.CurrentDomain.BaseDirectory}");
            Console.WriteLine($"AppContext.BaseDir {AppContext.BaseDirectory}");
            Console.WriteLine($"Runtime Call {Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");

            // 正在执行代码的程序集 -- Assembly.GetExecutingAssembly()
            Console.WriteLine($"manifest loaded file Location {Assembly.GetExecutingAssembly().Location.ToString()}");
            Console.WriteLine($"manifest loaded file Name {Assembly.GetExecutingAssembly().GetName().Name.ToString()}");
        }
    }
}