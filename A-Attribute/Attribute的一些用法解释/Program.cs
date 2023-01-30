using System.Runtime.CompilerServices;

// [assembly: AssemblyTitle("")]
// NOTE: 对于 Attribute, java比较相似的是 `注解`

string a = "a";
a.ToConvert();

/* 
 NOTE: 在特性中有一个特殊的 `目标词` [assembly:]
 并且无论其特性名是什么, 在何处
 只要其在程序集中, 就会被视为程序集级别的 Attribute
 NOTE: 程序集和模块特性必须位于文件中定义的所有其他元素之前(using 子句和外部别名声明除外)
 */

// 可以将类标注为 可序列化的
// [Serializable]
[type: Serializable]// 也可显式
public class Demo
{
    // 可以将某些字段标注为 不序列化
    [NonSerialized]
    // [field: NonSerialized]// 也可显式标注
    private static int _name;

    // [NonSerialized]// Error. 特性“NonSerialized”对此声明类型无效。它仅对“字段”声明有效。
    // Tips: 只需要显式标注为 [field: NonSerialized]
    // NOTE: 编译器就会自动应用于`属性`里面自动实现的`隐藏字段`
    [field: NonSerialized]// 此处是应用到了自动实现的字段中
    public int Id { get; set; }

    // C++: thread_local static int myInt;
    // 想要实现与上方C++语句同等效果, 可以使用 [ThreadStatic]
    [ThreadStatic]
    public int myInt;
}

public static class Demo2
{
    // C# 写拓展方法可以使用 this关键字
    public static string ToConvert(this string original)
    {
        return "";
    }
    // 但是 VB是没有这种写法的, 不过可以使用 特性来标注 标注为 V<Extension()>
    // [Extension]// Error. 不要使用“System.Runtime.CompilerServices.ExtensionAttribute”。请改用“this”关键字。
    // public static string ToConvert2(string original)
    // {
    //     return "";
    // }
}

