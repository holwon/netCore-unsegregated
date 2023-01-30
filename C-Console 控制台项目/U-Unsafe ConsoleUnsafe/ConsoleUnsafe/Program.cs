using System;

namespace ConsoleUnsafe
{
    // 开启不安全模式只需要在
    // .csproj 文件中添加
    // <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    // <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    // </PropertyGroup>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
