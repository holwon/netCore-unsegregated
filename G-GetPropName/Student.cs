using System.Linq.Expressions;

public record Student : Person
{
    public Student(string name, int age, string education) : base(name, age)
     => (Name, Age, Education) = (name, age, education);

    public object Education { get; private set; }
}