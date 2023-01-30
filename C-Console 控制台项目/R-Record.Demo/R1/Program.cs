
var record1 = new Record1("John", "Doe");
var record2 = new Record1("John", "Doe");
var record3 = new Record1("wuhu", "ok");

var cls1 = new Class1("John", "Doe");
var cls2 = new Class1("John", "Doe");

Console.WriteLine($"---record---");
// System.Console.WriteLine(Record1.Equals(Record2));
Console.WriteLine("Equals(record1, record2): -->" + Equals(record1, record2));
Console.WriteLine("ReferenceEquals(record1, record2): -->" + ReferenceEquals(record1, record2));
Console.WriteLine("Record1.ReferenceEquals(record1, record2): -->" + Record1.ReferenceEquals(record1, record2));
// Console.WriteLine(ReferenceEqualityComparer.Equals(Record1, Record2));
// ------------------------------------------
Console.WriteLine();
Console.WriteLine("getHashCode(record1): -->" + record1.GetHashCode());
Console.WriteLine("getHashCode(record2): -->" + record2.GetHashCode());
Console.WriteLine("getHashCode(record3): -->" + record3.GetHashCode());
Console.WriteLine();
// ------------------------------------------


// record的用法

// 这个是使用 `析构函数` 做成的, 把记录`解构`成了他的组成部分
var (fn, ln) = record1;
Console.WriteLine($"The value 'fn' is {fn}, and the value 'ln' is {ln}");
// 因为 record 都是只读的, 所以想要修改他们的值的话, 只能创建一个副本

var record4 = new Record1(fn, ln);
Record1 r1d = record1 with { FirstName = "Tim" };
Console.WriteLine($"rd4: {r1d}");

Record2 r2a = new Record2("Tim", "test");

Console.WriteLine($"r2a: {r2a}");// 没有输出 FirstName
// 会输出 Record2 里面的 public 属性
// output r2a: Record2 { LastName = test }

Console.WriteLine($"r2a.FirstName: {r2a.FirstName}, r2a.LastName: {r2a.LastName}");
// output r2a.FirstName: Tim, r2a.LastName: test




System.Console.WriteLine("\n");
// =================================================
// =================================================
Console.WriteLine($"---class---");
// System.Console.WriteLine(cls1.Equals(cls2));
Console.WriteLine("Equals(cls1, cls2): -->" + Equals(cls1, cls2));
Console.WriteLine("ReferenceEquals(cls1, cls2): -->" + ReferenceEquals(cls1, cls2));
Console.WriteLine("Class1.ReferenceEquals(cls1, cls2): -->" + Class1.ReferenceEquals(cls1, cls2));
Console.WriteLine();
// record相同的值 getHashCode 会相同
Console.WriteLine("getHashCode(cls1): -->" + cls1.GetHashCode());
Console.WriteLine("getHashCode(cls2): -->" + cls2.GetHashCode());



// destructor




// 注意 FirstName 和 LastName 的命名方式, 都是首字母大写的
// 原因是: 使用 record 时, 他实际在幕后做了大量工作

// C# 9 引入了记录，这是一种可以创建的新引用类型，而不是类或结构。  

// C# 10 添加了 record structs，以便你可以将记录定义为值类型。

// a Record1 is a fancy class
// Immutable - can't change the value of a record -> 他是不可改变的, 只读的
public record Record1(string FirstName, string LastName);
// record是通过变量名识别的
public record User1(int Id, string FirstName, string LastName) : Record1(FirstName, LastName);
public record Record2(string FirstName, string LastName)
{
    // internal却不能被隐式转换输出
    internal string FirstName { get; init; } = FirstName;
    public string FullName { get => $"{FirstName} {LastName}"; }
}




// 一个与 Record1 相同的记录结构
public class Class1
{
    public Class1(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // init 关键字即仅在构造函数中或创建时设置属性
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public void DeConstructor(out string firstName, out string lastName)
    {
        firstName = FirstName;
        lastName = LastName;
    }
}
