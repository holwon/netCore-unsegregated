using System.Threading;
using System;

namespace 共享
{
    class ThreadTest
    {
        bool _done;
        static void Main(string[] args)
        {
            ThreadTest tt = new ThreadTest();
            new Thread(tt.GO).Start();
            tt.GO();
            Console.ReadLine();
        }
        private void GO()
        {
            if (!_done)
            {
                _done = true;
                Console.WriteLine("Done");
                return;
            }
        }
    }
}
