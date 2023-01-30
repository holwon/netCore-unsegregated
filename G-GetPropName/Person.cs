using System.Linq.Expressions;

public record Person
{
    public Person(string name, int age) => (Name, Age) = (name, age);

    public string Name { get; set; }
    public int Age { get; set; }

    public static string PropName(Expression<Func<Object>> expr)
    {
        Expression e = expr.Body;
        MemberExpression me = e as MemberExpression;
        if (me == null)
        {
            UnaryExpression ue = e as UnaryExpression;
            me = ue.Operand as MemberExpression;
        }
        return me.Member.Name;
    }
    // public void Deconstructor(out string name, out int age) => (name, age) = (Name, Age);
}