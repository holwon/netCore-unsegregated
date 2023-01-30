// See https://aka.ms/new-console-template for more information
await MainAsync();
System.Console.WriteLine("Press any key to exit...");
Console.ReadLine();

async Task MainAsync()
{
    await MakeTeaAsync();

}

async Task<string> MakeTeaAsync()
{

    var boilingWater = BoilWaterAsync();
    System.Console.WriteLine("take a cup");
    System.Console.WriteLine("put tea in cup");

    var a = 0;
    // 编译器不会管这里，即使没有运算完成，也不会等待
    for (int i = 0; i < 100_000_000; i++)
    {
        a += i;
    }
    var water = await boilingWater;
    var tea = $"pour {water} into cup";
    System.Console.WriteLine(tea);
    return tea.ToString();
}

async Task<string> BoilWaterAsync()
{
    System.Console.WriteLine("start the kettle and add water");
    System.Console.WriteLine("waiting for the kettle to boil");
    await Task.Delay(500);// 烧水 simulate waiting for the kettle to boil 
    System.Console.WriteLine("kettle finished boiling");
    // await Task.FromResult("water");
    return "water";
}




void Main()
{
    MakeTea();
}

string MakeTea()
{
    var water = BoilWater();
    System.Console.WriteLine("take a cup");
    System.Console.WriteLine("put tea in cup");
    var tea = Pour(water);
    System.Console.WriteLine(tea);
    return tea.ToString();
}

object Pour(object water)
{
    System.Console.WriteLine($"pour {water} into cup");
    return "new Tea()";
}

string BoilWater()
{
    System.Console.WriteLine("start the kettle and add water");
    System.Console.WriteLine("waiting for the kettle to boil");
    Task.Delay(2000).Wait();// 烧水 simulate waiting for the kettle to boil 
    System.Console.WriteLine("kettle finished boiling");
    return "new Water()";
}