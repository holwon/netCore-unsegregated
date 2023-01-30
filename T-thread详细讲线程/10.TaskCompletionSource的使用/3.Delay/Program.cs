
// See https://aka.ms/new-console-template for more information
void Main()
{
    // 这个 Delay 是我们自己实现的
    Delay(6000).GetAwaiter().OnCompleted(() =>
    {
        Console.WriteLine("After 5 seconds!");
    });

    // Task.Delay 相当于异步版本的 sleep
    Task.Delay(1000).ContinueWith(task =>
    {
        Console.WriteLine("After 5 seconds! Async!");
    });
}


// C#也有自带的 Delay
System.Console.WriteLine("Hello World!");
Main();
Console.ReadLine();

Task Delay(int milliseconds)
{
    var tsc = new TaskCompletionSource<object>();
    var timer = new System.Timers.Timer(milliseconds);
    timer.Elapsed += (sender, e) =>
    {
        timer.Dispose();
        tsc.SetResult(null);
    };
    timer.Start();
    return tsc.Task;
}