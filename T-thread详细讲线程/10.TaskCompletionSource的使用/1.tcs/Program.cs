
Main();

void Main()
{
    // 注 TaskCompletionSource 都是泛型，必须要指定泛型类型
    var tcs = new TaskCompletionSource<int>();

    new Thread(() =>
    {
        Thread.Sleep(3000);
        tcs.SetResult(42);
    })
    {
        IsBackground = true
    }.Start();

    Task<int> task = tcs.Task;
    System.Console.WriteLine(task.Result);
}