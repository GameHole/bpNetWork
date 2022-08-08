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
    }
}
