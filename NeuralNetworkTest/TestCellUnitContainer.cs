using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestCellUnitContainer
    {
        CellUnitContainer cntr;
    
        [SetUp]
        public void SetUp()
        {
            cntr = new CellUnitContainer();
        }
        [Test]
        public void testGet()
        {
            Assert.AreEqual(0, cntr.Count);
            var unit = cntr.AddUnit<LogUnit>();
            Assert.AreSame(unit,cntr.GetUnit(typeof(LogChannal)));
            Assert.AreSame(unit, cntr.GetUnit<LogUnit>());
        }
        [Test]
        public void testAddUnit()
        {
            cntr.AddUnit<LogUnit>();
            Assert.AreEqual(1, cntr.Count);
        }
        [Test]
        public void testAddMore()
        {
            var unit = cntr.AddUnit<LogUnit>();
            Assert.Throws<ArgumentException>(() =>
            {
                cntr.AddUnit<LogUnit>();
            });
            Assert.AreEqual(1, cntr.Count);
        }
        [Test]
        public void testGetChannalType()
        {
            Assert.AreSame(typeof(LogChannal), cntr.getChannalType(typeof(LogUnit)));
        }
    }
}
