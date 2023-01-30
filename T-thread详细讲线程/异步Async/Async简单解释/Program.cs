// See https://aka.ms/new-console-template for more information

MainAsync();
Console.ReadLine();

async void MainAsync()
{
    System.Console.WriteLine("· 1\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
    var client = new HttpClient();
    System.Console.WriteLine("· 2\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
    var response = client.GetStringAsync("http://www.google.com");
    System.Console.WriteLine("· 3\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
    var a = 0;
    for (int i = 0; i < 100_000_000; i++)
    {
        a += i;
    }
    System.Console.WriteLine("· 4\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
    var page = await response;
    System.Console.WriteLine("· 5\n· ThreadID: " + Thread.CurrentThread.ManagedThreadId + "·" + Thread.CurrentThread.IsThreadPoolThread);
    // 试试 ValueType，文档说 ValueType 重写中的虚方法 Object ，并为值类型提供更合适的实现。 另请参见 Enum ，后者继承自 ValueType 。
    ValueType v = 123;
    Console.WriteLine(v + v.GetType().ToString());

}