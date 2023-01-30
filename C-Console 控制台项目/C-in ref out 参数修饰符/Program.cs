// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int t = 1;

Test_in_key(t);
Console.WriteLine(t);

Test_in_key2(ref t);
Console.WriteLine(t);

Test_in_key3(out t);
Console.WriteLine(t);



/// <summary>
/// in 关键字会导致按引用传递参数，但确保未修改参数。 
/// 它让形参成为实参的别名，这必须是变量。 
/// 换而言之，对形参执行的任何操作都是对实参执行的。 
/// </summary>
/// <param name="t1"></param>
void Test_in_key(in int t1)
{
    System.Console.WriteLine("Test_in_key1");
    // t1 = 2;// 无法分配到 变量 'in int' ，因为它是只读变量
}

void Test_in_key2(ref int t2)
{
    System.Console.WriteLine("Test_in_key2");
    t2 = 2;
}

void Test_in_key3(out int t3)
{
    System.Console.WriteLine("Test_in_key3");
    // 控制离开当前方法之前必须对 out 参数“t3”赋值[in关键字]csharp(CS0177)\
    t3 = 3;
}