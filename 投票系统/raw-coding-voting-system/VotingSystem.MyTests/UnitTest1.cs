using System.Diagnostics.Contracts;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace VotingSystem.MyTests
{
    public class Math1
    {
        private readonly ITest1 test1;

        public Math1(ITest1 test1)
        {
            this.test1 = test1;
        }

        public int Add(int a, int b) => test1.Add(a, b);
        public void Out() => test1.Out();
    }

    public class Math1Tests
    {
        [Fact]
        public void Add_Should_Return_Sum_Of_Two_Numbers()
        {
            // System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            var test1Mock = new Mock<ITest1>();
            test1Mock.Setup(x => x.Add(1, 2)).Returns(3);
            var math1 = new Math1(test1Mock.Object);
            // var math = new Math1(new Test1());
            var result = math1.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void VerifyFunctionHasBeenCalled()
        {
            // System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            var test1Mock = new Mock<ITest1>();
            var math1 = new Math1(test1Mock.Object);
            math1.Out();
            test1Mock.Verify(x => x.Out(), times: Times.Once);
        }
    }

    public interface ITest1
    {
        public int Add(int a, int b);
        public void Out();
    }

    public class Test1 : ITest1
    {
        public int Add(int a, int b) => a + b;

        public void Out()
        {
            System.Console.WriteLine("Test1.Out");
        }

        public int Subtract(int a, int b) => a - b;
    }

    public class UnitTest1
    {
        [Fact]
        public void Add_AddTwoNumberTogether()
        {
            var result = new Test1().Add(1, 2);
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 1, 2)]
        [InlineData(0, 2, 2)]
        public void Add_AddTwoNumberTogether_Theory(int a, int b, int expected)
        {
            var result = new Test1().Add(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestListContainsValue()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.True(list.Contains(1));
            Assert.Contains(1, list);
        }
    }
}