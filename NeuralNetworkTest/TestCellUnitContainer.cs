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
        CellUnit unit;
        [SetUp]
        public void SetUp()
        {
            cntr = new CellUnitContainer();
            unit = new CellUnit(typeof(ActiveChannal),new ActiveAction());
        }
        [Test]
        public void testGet()
        {
            Assert.AreEqual(0, cntr.Count);
            cntr.AddUnit(unit);
            Assert.AreEqual(1, cntr.Count);
            Assert.AreSame(unit, cntr.GetUnit(typeof(ActiveChannal)));
            Assert.AreSame(unit.Action, cntr.GetUnit<ActiveChannal, ActiveAction>());
        }
        [Test]
        public void testAddUnit()
        {
            cntr.AddUnit(unit);
            Assert.AreEqual(1, cntr.Count);
        }
        [Test]
        public void testAddMore()
        {
            cntr.AddUnit(unit);
            Assert.Throws<ArgumentException>(() =>
            {
                cntr.AddUnit(unit);
            });
            Assert.AreEqual(1, cntr.Count);
        }
        //[Test]
        //public void testGetChannalType()
        //{
        //    Assert.AreSame(typeof(LogChannal), cntr.getChannalType(typeof(LogUnit)));
        //}
    }
}
