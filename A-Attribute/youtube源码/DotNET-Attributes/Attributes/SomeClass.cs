using System;

namespace Attributes
{
    [Serializable]
    internal class SomeClass
    {
        [field: NonSerialized]
        public int MyInt { get; set; }

        //[ThreadStatic]
        //private static int myInt;

        //public static string ToKebab (this string original)
        //{
        //    return "";
        //}
    }
}
