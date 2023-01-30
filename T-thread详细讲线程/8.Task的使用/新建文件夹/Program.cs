int aa = 0;

System.Console.WriteLine("thread is running...");

// 这样的代码，可以被线程共享 aa
ThreadStart action = () =>
{
    // 返回一个数字，该数字表示指定序列中有多少元素满足条件。
    aa = Enumerable.Range(1, 8).Count(
    // 判断是否是素数 素数是指质数
    // 如果一个数字不是素数，那么必定可以表示为a x b的形式，这里假如a为较小的数，那么a<= sqrt(number)，如果试到平方根，还是找不到这个a的话，就一定是素数咯。✌️
    x => Enumerable.Range(2, (int)Math.Sqrt(x) - 1).All(y => x % y != 0));
    System.Console.WriteLine("Thread :" + Convert.ToString(aa));
};
new Thread(action) { Name = "test" }.Start();
// new Thread(action).Start();

#region Enumerable的使用
System.Console.WriteLine(Enumerable.Range(0, 2).Count());

System.Console.WriteLine("enum test :" +
    Enumerable.Range(1, 1000000).Count(// Count 返回一个数字，该数字表示指定序列中有多少元素满足条件。    
        Enumerable.Range(1, 100).Contains));// Contains就是会去查找是否包含这个值
#endregion
Console.ReadLine();
System.Console.WriteLine("main :" + aa);
Console.ReadLine();


