using System;
using System.Threading;

namespace VolatileUSE
{
    public class Worker
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            bool work = false;
            while (!_shouldStop)
            {
                work = !work; // simulate some work //模拟一些工作
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
            // Worker thread: 优雅地终止
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private volatile bool _shouldStop;
        // 关键字volatile被用来提示编译器这个数据成员被多个线程访问。
    }

    public class WorkerThreadExample
    {
        public static void Main()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            // 循环，直到 Worker 线程激活。
            while (!workerThread.IsAlive)//判断线程是否存活,如果存活就跳出循环
                ;

            // Put the main thread to sleep for 500 milliseconds to
            // allow the worker thread to do some work.
            Thread.Sleep(500);//睡眠 main thread 500毫秒,让 Worker 线程做一些工作

            // Request that the worker thread stop itself.
            workerObject.RequestStop();//请求 Worker 线程停止自己

            // Use the Thread.Join method to block the current thread
            // until the object's thread terminates.
            workerThread.Join();//使用 Thread.Join 方法阻塞当前线程，直到对象的线程终止。
            Console.WriteLine("Main thread: worker thread has terminated.");
            // Console.ReadKey();
        }
        // Sample output:
        // Main thread: starting worker thread...
        // Worker thread: terminating gracefully.
        // Main thread: worker thread has terminated.
    }
}
