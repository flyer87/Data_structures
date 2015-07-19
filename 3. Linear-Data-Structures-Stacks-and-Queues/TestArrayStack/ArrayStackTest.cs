using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayStack;

namespace TestArrayStack
{
    [TestClass]
    public class ArrayStackTest
    {
        [TestMethod]
        public void TestPushPopElement()
        {
            var stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);

            stack.Push(1);
            Assert.AreEqual(1, stack.Count);

            var item = stack.Pop();
            Assert.AreEqual(1, item);

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void Test1000PushPopElements()
        {
            ArrayStack<string> stack = new ArrayStack<string>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i.ToString());
                Assert.AreEqual(i + 1, stack.Count);
            }

            for (int i = 0; i < 1000; i++)
            {
                var item = stack.Pop();
                Assert.AreEqual((1000 - i - 1).ToString(), item);
                Assert.AreEqual(1000 - i - 1, stack.Count);
            }         
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopFromEmptyString()
        {
            var stack = new ArrayStack<int>();
            stack.Pop();
        }
        
        [TestMethod]
        public void TestPushPopWithInitialCapacity()
        {
            var stack = new ArrayStack<int>(1);
            Assert.AreEqual(0, stack.Count);

            stack.Push(1);
            Assert.AreEqual(1, stack.Count);

            stack.Push(-1);
            Assert.AreEqual(2, stack.Count);

            var item = stack.Pop();
            Assert.AreEqual(-1, item);

            Assert.AreEqual(1, stack.Count);

            item = stack.Pop();
            Assert.AreEqual(1, item);

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestToArray()
        {
            var stack = new ArrayStack<int>();
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            int[] arrayFromStack = stack.ToArray();
            for (int i = 0; i < arrayFromStack.Length; i++)
            {
                Assert.AreEqual(arrayFromStack[arrayFromStack.Length - 1 - i], stack.Pop());
            }
        }

        [TestMethod]
        public void TestEmptyStackToArray()
        {
            var stack = new ArrayStack<DateTime>();
            DateTime[] dates = stack.ToArray();
            Assert.AreEqual(0, dates.Length);
        }
    }
}
