Person person = new("zhangsan", 10);
Student li4 = new("li4", 11, "benke");


System.Console.WriteLine(person);
Console.WriteLine($"{li4}");


Console.WriteLine($"{Student.PropName(() => li4.Name)}");

Console.WriteLine($"{nameof(li4.Age)}");

