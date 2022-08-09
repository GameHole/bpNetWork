using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestCellUnit
    {
        LogUnit unit;
        [SetUp]
        public void SetUp()
        {
            unit = new LogUnit();
        }
        [Test]
        public void testAddChannal()
        {
            var bulge = new Bulge();
            var lastCell = new Cell();
            var unitCell = new Cell();
            var last = new LogUnit();
            last.cell = lastCell;
            unit.cell = unitCell;
            unit.AddChannal(bulge);
            var log = bulge.units.GetUnit<LogChannal>();
            Assert.NotNull(log);
            Assert.AreSame(bulge, log.bulge);
        }
        [Test]
        public void testCellUnit()
        {
            var unit = new CellUnit<LogChannal, LogUnitAction>(true);
            Assert.IsTrue(unit.activeInverse);
            Assert.AreSame(typeof(LogChannal),unit.ChannalType);
            var cell = new Cell();
            unit.cell = cell;
            Assert.AreSame(cell, unit.action.cell);
            unit.ActiveSelf();
            Assert.AreEqual("active ", unit.action.log);
        }
    }
}
