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
        Cell cell;
        [SetUp]
        public void SetUp()
        {
            cell = new Cell();
            cntr = new CellUnitContainer(cell);
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
            var unit = cntr.AddUnit<LogUnit>();
            Assert.AreEqual(1, cntr.Count);
            Assert.AreSame(unit.cell, cell);
        }
        [Test]
        public void testAddMore()
        {
            var unit = cntr.AddUnit<LogUnit>();         
            for (int i = 0; i < 2; i++)
            {
                Assert.AreSame(unit, cntr.AddUnit<LogUnit>());
            }
            Assert.AreEqual(1, cntr.Count);
        }
    }
}
