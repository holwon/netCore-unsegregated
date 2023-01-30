using System;
using System.Threading;

public class Example
{
    static Thread thread1, thread2;

    public static void Main()
    {
        thread1 = new Thread(ThreadProc);
        thread1.Name = "Thread1";
        thread1.Start();

        thread2 = new Thread(ThreadProc);
        thread2.Name = "Thread2";
        thread2.Start();
        Console.ReadLine();

    }

    private static void ThreadProc()
    {
        Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
        if (Thread.CurrentThread.Name == "Thread1" &&
            thread2.ThreadState != ThreadState.Unstarted)
        {
            //如果线程已经终止，则为True; 如果之后线程没有终止，则为False  
            if (thread2.Join(2000))
            {
                // 如果两秒后 Thread2 已经终止，则走到这里
                System.Console.WriteLine("Thread2 has been terminated\n" +
                    "Thread2 state: {0}", thread2.ThreadState);
            }
            else
            {
                // 如果两秒后 Thread2 没有终止，则走到这里
                // 超时后 Thread1 会重新唤醒
                System.Console.WriteLine("The timeout has elapsed " +
                                         "and Thread1 will resume\n" +
                                         "超时后 Thread1 会重新唤醒");
            }
        }
        Thread.Sleep(5000);
        Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
        Console.WriteLine("Thread1: {0}", thread1.ThreadState);
        Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);
        if (Thread.CurrentThread.Name == "Thread2")
        {
            System.Console.WriteLine("Thread2 will terminate and Thread1 will resume");
        }
    }
}
// The example displays output like the following:
//       Current thread: Thread1
//       
//       Current thread: Thread2
//       
//       Current thread: Thread2
//       Thread1: WaitSleepJoin
//       Thread2: Running
//       
//       
//       Current thread: Thread1
//       Thread1: Running
//       Thread2: Stopped