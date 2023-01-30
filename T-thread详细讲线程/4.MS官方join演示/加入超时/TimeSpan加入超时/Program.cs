using System.Threading;
using System;
class Program
{
    //TimeSpan.TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds
    // static TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 100);
    static TimeSpan waitTime = new TimeSpan(0, 0, 0, 1);//1 second
    public static void Main(string[] args)
    {
        Thread newThread = new Thread(new ThreadStart(Work));
        newThread.Start();

        // 如果线程能够在指定的时间内(2 seconds)完成，则继续执行
        if (newThread.Join(waitTime + waitTime))
        {
            Console.WriteLine("Thread finished");
        }
        else
        {
            Console.WriteLine("Thread timed out");
        }
    }

    private static void Work()
    {
        Thread.Sleep(waitTime);
    }
}