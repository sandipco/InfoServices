using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace QueueImplementation.Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void CheckEmpty()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            bool isEmpty = queue.IsEmpty;
            Assert.AreEqual(true, isEmpty);
        }
        [TestMethod]
        public void CheckEnqueue()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.EnQueue(2);
            int length = queue.Length;
            int element = queue.Peek();
            Assert.AreEqual(length, 1);
            Assert.AreEqual(2, element);
        }
        [TestMethod]
        public void CheckPeek()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
            queue.EnQueue(3.14);
            queue.EnQueue(6.78);
            double element = queue.Peek();
            Assert.AreEqual(3.14, element);
            Assert.AreEqual(2, queue.Length);
        }
        [TestMethod]
        public void CheckeDequeue()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
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
                CustomQueue<double> queue = new CustomQueue<double>();
                double element = queue.Dequeue();
            }
            catch(System.Exception ex)
            {
                s = ex.GetType().ToString();
            }
            Assert.AreEqual("System.InvalidOperationException", s);
            
        }
        [TestMethod]
        public void CheckeReverseQueue()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
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
            CustomQueue<double> queue = new CustomQueue<double>();
            queue.Reverse();
            Assert.AreEqual(0, queue.Length);

        }
        [TestMethod]
        public void Contains()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
            queue.EnQueue(3.14);
            queue.EnQueue(8.28);
            queue.EnQueue(1.1987);
            queue.EnQueue(5.39);
            Assert.AreEqual(true, queue.Contains(1.1987));
        }
        [TestMethod]
        public void CheckLength()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.EnQueue("ABC");
            queue.EnQueue("XYZ");
            Assert.AreEqual(2, queue.Length); 

        }
        [TestMethod]
        public void CheckZeroLength()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
            Assert.AreEqual(0, queue.Length);

        }
        [TestMethod]
        public void CheckReverseCopy()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.EnQueue("ABC");
            queue.EnQueue("XYZ");
            List<string> revQueue = queue.ReverseCopy().ToList();
            Assert.AreEqual("XYZ", revQueue[0]);
        }

    }
}
