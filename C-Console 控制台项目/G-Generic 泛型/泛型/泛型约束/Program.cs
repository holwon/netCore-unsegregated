namespace 泛型约束
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("**********泛型约束**********");
            {
                People people = new People() { Id = 1, Name = "张三" };
                Student student = new Student() { Id = 2, Name = "李四" };
                Teacher teacher = new Teacher() { Id = 3, Name = "王五" };
                Martian martian = new Martian() { Id = 4, Name = "火星1" };
                try
                {
                    Show.ObjectShow(people);
                    Show.ObjectShow(student);
                    Show.ObjectShow(teacher);
                    Show.ObjectShow(martian);// 编译会报错，因为Martian不是People的子类
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                try
                {
                    Constrain.GenericShow<People>(people);
                    Constrain.GenericShow<Student>(student);
                    Constrain.GenericShow<Teacher>(teacher);
                    {
                        // 编译器会直接报错,
                        // 因为Martian不是People的子类
                        // 由于我们加了泛型约束, 此方法只会接受People的类型
                        // Constrain.GenericShow<Martian>(martian);
                    }
                }
                catch (System.Exception ex)
                {
                    // TODO:
                    System.Console.WriteLine(ex.Message);
                }
            }

            Bird bird = new Bird();
            Bird parrot = new Parrot();

            List<Bird> birds = new List<Bird>();
            // List<Bird> parrots = new List<Parrot>();
            List<Bird> parrots = new List<Parrot>().Select(x => (Bird)x).ToList();
        }
    }
}