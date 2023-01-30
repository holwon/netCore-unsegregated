namespace 泛型
{
    public class T
    {
        public static void PrintArray<T>(IList<T> array)
        {
            foreach (T element in array)
            {
                System.Console.WriteLine(element);
            }
            // System.Console.WriteLine(value);
            // return value;
        }
    }
}