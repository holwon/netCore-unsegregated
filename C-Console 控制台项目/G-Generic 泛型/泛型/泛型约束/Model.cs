namespace 泛型约束
{
    public interface ISport
    {
        void PingPang();
    }
    public interface IWork
    {
        void Work();
    }
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Hi()
        {

        }
    }

    public class Student : People
    {
        public void Tradition()
        {
            System.Console.WriteLine("仁义明德.");
        }
        public new void Hi() => System.Console.WriteLine("Hi, I'm a student.");
    }
    public class Teacher : People
    {
        public void Tradition(int a)
        {
            System.Console.WriteLine("有教无类.");
        }
        public new void Hi() => System.Console.WriteLine("Hi, I'm a teacher.");
    }

    /// <summary>
    /// <className name="Martian">火星人</className>
    /// </summary>
    public class Martian : ISport, IWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void PingPang()
        {
            System.Console.WriteLine("PingPang");
        }
        public void Work()
        {
            System.Console.WriteLine("Work");
        }
    }
}