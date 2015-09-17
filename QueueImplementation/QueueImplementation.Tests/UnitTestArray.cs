using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueueImplementation.Tests
{
    /// <summary>
    /// Summary description for UnitTestArray
    /// </summary>
    [TestClass]
    public class UnitTestArray
    {
        [TestMethod]
        public void CheckEmpty()
        {
            CustomQueueWithArray<int> queue = new CustomQueueWithArray<int>(10);
            bool isEmpty = queue.IsEmpty;
            Assert.AreEqual(true, isEmpty);
        }
        [TestMethod]
        public void CheckEnqueue()
        {
            CustomQueueWithArray<int> queue = new CustomQueueWithArray<int>(10);
            queue.EnQueue(2);
            int length = queue.Length;
            int element = queue.Peek();
            Assert.AreEqual(length, 1);
            Assert.AreEqual(2, element);
        }
        [TestMethod]
        public void CheckPeek()
        {
            CustomQueueWithArray<double> queue = new CustomQueueWithArray<double>(10);
            queue.EnQueue(3.14);
            queue.EnQueue(6.78);
            double element = queue.Peek();
            Assert.AreEqual(3.14, element);
            Assert.AreEqual(2, queue.Length);
        }
        [TestMethod]
        public void CheckeDequeue()
        {
            CustomQueueWithArray<double> queue = new CustomQueueWithArray<double>(10);
            queue.EnQueue(3.14);
            queue.EnQueue(8.28);
            queue.EnQueue(1.1987);
            queue.EnQueue(5.39);

            double element = queue.Dequeue();
            int length = queue.Length;
            Assert.AreEqual(3.14, element);
            Assert.AreEqual(3, length);
        }
        [TestMethod]
        public void CheckeDequeueWhenEmpty()
        {
            string s = string.Empty;
            try
            {
                CustomQueueWithArray<double> queue = new CustomQueueWithArray<double>(10);
                double element = queue.Dequeue();
            }
            catch (System.Exception ex)
            {
                s = ex.GetType().ToString();
            }
            Assert.AreEqual("System.InvalidOperationException", s);

        }
        [TestMethod]
        public void CheckeReverseQueue()
        {
            CustomQueueWithArray<double> queue = new CustomQueueWithArray<double>(10);
            queue.EnQueue(3.14);
            queue.EnQueue(8.28);
            queue.EnQueue(1.1987);
            queue.EnQueue(5.39);

            queue.Reverse();
            double element = queue.Dequeue();
            Assert.AreEqual(5.39, element);

        }
        [TestMethod]
        public void CheckeReverseZeroLengthQueue()
        {
            CustomQueueWithArray<double> queue = new CustomQueueWithArray<double>(10);
            queue.Reverse();
            Assert.AreEqual(0, queue.Length);

        }
        [TestMethod]
        public void Contains()
        {
            CustomQueueWithArray<string> queue = new CustomQueueWithArray<string>(10);
            queue.EnQueue("Pizza");
            queue.EnQueue("Burger");
            queue.EnQueue("Spaghetti");
            queue.EnQueue("Dumplings");
            Assert.AreEqual(true, queue.Contains("Burger"));
        }
        [TestMethod]
        public void CheckLength()
        {
            CustomQueueWithArray<string> queue = new CustomQueueWithArray<string>(10);
            queue.EnQueue("ABC");
            queue.EnQueue("XYZ");
            Assert.AreEqual(2, queue.Length);

        }
        [TestMethod]
        public void CheckZeroLength()
        {
            CustomQueueWithArray<double> queue = new CustomQueueWithArray<double>(10);
            Assert.AreEqual(0, queue.Length);

        }
        [TestMethod]
        public void CheckReverseCopy()
        {
            CustomQueueWithArray<string> queue = new CustomQueueWithArray<string>(10);
            queue.EnQueue("ABC");
            queue.EnQueue("XYZ");
            List<string> revQueue = queue.ReverseCopy().ToList();
            Assert.AreEqual("XYZ", revQueue[0]);
        }

    }
}

