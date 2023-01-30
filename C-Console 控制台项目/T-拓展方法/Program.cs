string str = "string";
Console.WriteLine(str.WordCount());

public static class StringExtensions
{
    // 加上个 this关键字就可以表示为该类型的拓展方法
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
    }
}