using System.Collections;

namespace IEnumerator的使用
{
    /// <summary>
    /// IEnumerable 可枚举类型 -- 可迭代的类型
    /// IEnumerator 枚举器
    /// 
    /// 只要一个类型实现了IEnumerable接口，那么它就是一个可枚举类型
    /// </summary>
    public class IEnumerableShow
    {
        public void Show()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            string str = "Hello World";
            Student student = new Student { Id = 1, Name = "张三", Age = 18 };
            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Student : IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public IEnumerator GetEnumerator()
        {
            // yield return Id; // 也就是说 yield return 会生成一个迭代器(IEnumerator), yield 实现了迭代器的接口
            // yield return 2;
            // yield return 3;
            string[] student = { "张三", "李四", "王五" };
            return new StudentEnumerator(student);
        }

    }

    internal class StudentEnumerator : IEnumerator
    {
        private string[] _student;
        private int _index = -1;
        public StudentEnumerator(string[] student)
        {
            this._student = student;
        }

        public object Current
        {
            get
            {
                // 如果 _index=-1, 则代表没有迭代到任何一个元素
                if (_index == -1)
                {
                    // 抛出验证异常
                    throw new InvalidOperationException();
                }
                // 如果 _index>=_student.Length, 则代表已经迭代到最后一个元素且超出了数组的范围
                if (_index >= _student.Length)
                {
                    throw new InvalidOperationException();
                }
                return _student[_index];
            }
        }

        public bool MoveNext()
        {
            // 如果 _index < _student.Length - 1, 则代表还有下一个元素
            if (_index < _student.Length - 1)
            {
                _index++; // 迭代到下一个元素
                return true; // 也就是说返回true, 我们就可以继续迭代 
            }
            else
            {
                return false; // 否则就返回false, 我们就不能继续迭代了
            }
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}