Main();

//Main function
void Main()
{
    var awaiter = GetAnswerToLife().GetAwaiter();
    // 完成后调用，类似于回调函数
    awaiter.OnCompleted(() =>
    {
        Console.WriteLine("The answer to life is {0}", awaiter.GetResult());
    });
    Console.ReadLine();

}

Task<int> GetAnswerToLife()
{
    var tcs = new TaskCompletionSource<int>();//创建task不需要占用线程，相当于异步的thread.sleep()
    var timer = new System.Timers.Timer(5000) { AutoReset = false };
    // timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(42); };
    timer.Elapsed += (s, e) => { timer.Dispose(); tcs.SetResult(43); };
    timer.Start();
    return tcs.Task;
}

