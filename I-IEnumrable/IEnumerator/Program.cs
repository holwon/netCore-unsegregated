IEnumerable<int> GetNumbers()
{
    yield return 1;
    yield return 2;
    yield return 3;
    // 这里会，yield return完 1 2 3后, 才会继续执行
    Console.WriteLine("GetNumbers");
}


// foreach (var i in GetNumbers())
// {
//     Console.WriteLine(i);
// }




List<Student> students = new()
{
    new Student() { Id = 1, Name = "张三" },
    new Student() { Id = 2, Name = "李四" }
};

Student? Get(int id) => students.FirstOrDefault(x => x.Id == id);

System.Console.WriteLine(value: Get(2)?.Name);


class Student
{
    public string Name { get; set; }
    public int Id { get; set; }
}