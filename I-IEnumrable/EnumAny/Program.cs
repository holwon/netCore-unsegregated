List<string> l = new List<string>();
l.Add("a");
l.Add("b");
l.Add("c");
// foreach (string s in l)
// {
//     System.Console.WriteLine(s);
// }
string? result = l.FirstOrDefault(x => x.Equals("b"));
bool result2 = l.Any(x => x.Equals("b"));// 是否有元素==b
bool result3 = l.Any(x => x.Equals("dd"));

System.Console.WriteLine(result);
Console.WriteLine(result2);
Console.WriteLine(result3);