System.Console.WriteLine("Hello World!");

public class Parent
{
    public virtual int TestProperty
    {
        // Notice the accessor accessibility level.
        protected set { }

        // No access modifier is used here.
        get { return 0; }
    }
}
public class Kid : Parent
{
    public override int TestProperty
    {
        // Use the same accessibility level as in the overridden accessor.
        // 访问修饰符必须与父类相同
        // 访问修饰符重写时不能更改
        protected set { }

        // Cannot use access modifier here.
        get { return 0; }
    }
}