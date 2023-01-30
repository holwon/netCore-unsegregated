using System;

namespace enum1
{
    class Program
    {
        enum a { z, e = 5, s = 5, l = 0, j }
        static void Main(string[] args)
        {
            //不能在main里面直接定义枚举enum
            //enum a { z, e = 5, s = 5, l = 0, j }
            string sa = a.e.ToString();
            int jj = ((int)a.z);
            Console.WriteLine(jj);
        }
    }
}
