using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    internal class TestClass : LogUnit
    {
    }
    class TestContainer
    {
        Container<ICellUnit> cntr;
        [SetUp]
        public void SetUp()
        {
            cntr = new Container<ICellUnit>();
        }
        [Test]
        public void testContainer()
        {
            Assert.AreEqual(0, cntr.Count);
        }
        [Test]
        public void testGet()
        {
            var log = new LogUnit();
            cntr.Add(typeof(LogUnit), log);
            Assert.NotNull(cntr.Get(typeof(LogUnit)));
            Assert.AreSame(log, cntr.Get(typeof(LogUnit)));
        }
        
        [Test]
        public void testAdd()
        {
            LogUnit log = new LogUnit();
            cntr.Add(typeof(TestTraining), log);
            Assert.AreSame(log, cntr.Get(typeof(TestTraining)));
        }
        [Test]
        public void testClear()
        {
            cntr.Add(typeof(LogUnit),new LogUnit());
            cntr.Clear();
            Assert.AreEqual(0, cntr.Count);
            Assert.Null(cntr.Get(typeof(LogUnit)));
        }
    }
}
