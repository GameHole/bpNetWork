using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestContainer
    {
        Container<object> cntr;
        object log;
        [SetUp]
        public void SetUp()
        {
            cntr = new Container<object>();
            log = new object();
        }
        [Test]
        public void testContainer()
        {
            Assert.AreEqual(0, cntr.Count);
        }
        [Test]
        public void testGet()
        {
            cntr.Add(typeof(LogUnit), log);
            Assert.NotNull(cntr.Get(typeof(LogUnit)));
            Assert.AreSame(log, cntr.Get(typeof(LogUnit)));
        }
        
        [Test]
        public void testAdd()
        {
            cntr.Add(typeof(TestTraining), log);
            Assert.AreSame(log, cntr.Get(typeof(TestTraining)));
        }
        [Test]
        public void testClear()
        {
            cntr.Clear();
            Assert.AreEqual(0, cntr.Count);
            Assert.Null(cntr.Get(typeof(LogUnit)));
        }
    }
}
