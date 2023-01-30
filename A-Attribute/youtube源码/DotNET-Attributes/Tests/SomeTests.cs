using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SomeTests
    {
        public static object[][] Data => new object[][]
        {
            new object[]{1m, 2m, 3m},
            new object[]{10m, 20m, 30m}
        };

        [DataTestMethod]
        [DynamicData (nameof(Data))]
        public void Addition(decimal a, decimal b, decimal result)
        {
            Assert.AreEqual(result, a + b);
        }

        [DataTestMethod]
        [DataRow("Hello")]
        public void SomeTest(string s)
        {

        }

    }
}
