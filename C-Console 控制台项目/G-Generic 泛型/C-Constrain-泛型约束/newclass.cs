namespace 泛型约束
{
    public class Bird { public int Id { get; set; } }
    public class Chicken : Bird { public string Name { get; set; } }
    public class Parrot : Bird
    {
        // 模仿说话
        public void imitate() { System.Console.WriteLine("imitate speak"); }
    }
}
