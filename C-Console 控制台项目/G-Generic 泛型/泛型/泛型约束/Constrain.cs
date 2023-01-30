namespace 泛型约束
{
    public interface IMyInterface<T>
    {
        void Show(T t);
    }
    public class Constrain
    {

        /// <summary>
        /// 可以定义多个泛型
        /// </summary>
        public static void GenericShow<T, W, R, E>(T t) where T : People
        where W : IMyInterface<T>// 可以做接口约束
        where R : struct// 值类型约束
        where E : new() // 无参数构造函数约束
        {
            T tNew = default(T);// 会根据类型来初始化
            R r = default(R);
            // W w = new W();
            E e = new E();
        }

        /// <summary>
        /// 使用泛型约束, 就解决了关于object的类型不安全的问题
        /// <para>
        /// 做了泛型约束
        /// 1. 可以使用基类的一切属性和方法
        /// 2. 保证接受的类型是 "基类" 或者 "基类" 的子类
        /// </summary>
        /// <param name="genericValue"></param>
        /// <typeparam name="T"></typeparam>
        public static void GenericShow<T>(T genericValue) where T : People
            // where T : class // 可以添加类型约束
        {
            System.Console.WriteLine(genericValue.Id + "," + genericValue.Name);
        }
    }
}