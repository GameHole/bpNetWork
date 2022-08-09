using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    internal class TestClass : CellUnitBase
    {
       
    }
    class TestContainer
    {
        Container<CellUnitBase> cntr;
        [SetUp]
        public void SetUp()
        {
            cntr = new Container<CellUnitBase>();
        }
        [Test]
        public void testContainer()
        {
            Assert.AreEqual(0, cntr.Count);
        }
        [Test]
        public void testGet()
        {
            var log = new TestClass();
            cntr.Add(typeof(LogUnit), log);
            Assert.NotNull(cntr.Get(typeof(LogUnit)));
            Assert.AreSame(log, cntr.Get(typeof(LogUnit)));
        }
        
        [Test]
        public void testAdd()
        {
            var log = new TestClass();
            cntr.Add(typeof(TestTraining), log);
            Assert.AreSame(log, cntr.Get(typeof(TestTraining)));
        }
        [Test]
        public void testClear()
        {
            cntr.Add(typeof(LogUnit),new TestClass());
            cntr.Clear();
            Assert.AreEqual(0, cntr.Count);
            Assert.Null(cntr.Get(typeof(LogUnit)));
        }
    }
}
