using System;
using System.IO;

namespace ClassLibrary1
{
    public class Class1
    {
        public static void PrintAssemblyLocation()
        {
            Console.WriteLine(typeof(FileStream).Assembly.Location);
        }
    }
}
