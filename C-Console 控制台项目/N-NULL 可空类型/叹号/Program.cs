var attributeExample = typeof(AttributeExample).GetCustomAttributes(true);
var att = attributeExample[0] as SerializableAttribute;
var att2 = attributeExample[0] as SerializableAttribute;

// 此处 att可能为空
Console.WriteLine($"{att.TypeId}");

// Tips: 使用 `!` 的主要作用就是告诉编译器，变量不可能为 null。
Console.WriteLine($"{att2!.TypeId}");


[Serializable]
internal class AttributeExample { }