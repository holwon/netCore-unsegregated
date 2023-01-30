var attributeExample = typeof(AttributeExample).GetCustomAttributes(true);
foreach (var attribute in attributeExample)
{
    if (attribute is Test2Attribute)
    {
        var att = attribute as Test2Attribute;
        System.Console.WriteLine($"attName: '{att!.Name}', attQuantity: {att.Quantity}");
    }
}


[Serializable]
[Test]
// [Test2("Attribute Test2")]
[Test2("Attribute Test2", Quantity = 1)]// 如函数一般赋值
internal class AttributeExample
{

}

[Serializable]
// [Test] // Error. 特性“Test”对此声明类型无效。它仅对“类”声明有效。 [A-Attribute]
public struct AttributeStruct { };

// 特性也可以有自己的 Attribute
[AttributeUsage(AttributeTargets.Class)]// 限定使用范围为 Class
public class TestAttribute : Attribute { }

// NOTE: AllowMultiple = true 允许给同一个Class,或其他类型, 指定多次
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
// 还可用来传递 构造函数/参数
public class Test2Attribute : Attribute
{
    private readonly string name;
    // 也可像函数一样传值
    public int Quantity;
    public Test2Attribute(string name)
    {
        this.name = name;
    }
    public string Name => name;
}