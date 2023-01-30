
// # 1. 不必在构造函数中限定初始化的值, 可用 `required` 关键字代替
var Jone = new Student { FirstName = "Jone", LastName = "yellow" };
Console.WriteLine(Jone.FirstName + " " + Jone.LastName);
public class Person
{
    public required string FirstName { get; set; }

    // required 即使是可空类型也能用
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
}

public class Student : Person
{
    public string ID { get; init; }
}