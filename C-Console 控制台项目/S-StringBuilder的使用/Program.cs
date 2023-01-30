using System.Text;

StringBuilder stringBuilder = new();
StringBuilder stringBuilder2 = new("string");// 也可以一开始就赋一些文本值

// Methods
stringBuilder.Append('-', 6);
stringBuilder.Append(" Here is a title ");
stringBuilder.Append('-', 6);

stringBuilder.AppendLine();
stringBuilder.Append(" And here is a paragraph ");

stringBuilder.Replace("And here is a paragraph", "Whops!");

stringBuilder.Remove(0, 30);

stringBuilder.Insert(0, 30);
stringBuilder.Insert(0, "hello");

System.Console.WriteLine(stringBuilder);

// stringBuilder2
stringBuilder2.Append(" How are you? ").AppendLine().Append(" I am great! ");

Console.WriteLine($"{stringBuilder2}");

