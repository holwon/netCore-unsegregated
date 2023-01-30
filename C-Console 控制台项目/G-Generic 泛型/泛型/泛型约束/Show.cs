namespace 泛型约束
{
    public static class Show
    {
        /// <summary>
        /// 首先, object类型因为会有装箱拆箱的问题, 会有性能损失
        /// <para>
        /// 其次, 还会有类型不安全的问题, 因为object类型是所有类型的父类
        /// </para>
        /// <para>
        /// 例如此处的: (People)objValue 所进行的强制转换
        /// 而我们是不知道传入的是什么类型的, 所以可能会报错
        /// </para>
        /// </summary>
        /// <param name="objValue"></param>
        public static void ObjectShow(object objValue)
        {
            System.Console.WriteLine(objValue.GetType());

            System.Console.WriteLine($"Id:{((People)objValue).Id},Name:{((People)objValue).Name}");
        }

    }
}