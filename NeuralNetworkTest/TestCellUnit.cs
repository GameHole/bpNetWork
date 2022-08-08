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
        public void testUnit()
        {
            Assert.AreEqual(0, unit.inputs.Count);
            Assert.AreEqual(0, unit.outputs.Count);
        }
        [Test]
        public void testAddFrom()
        {
            var bulge = new Bulge();
            var lastCell = new Cell();
            var unitCell = new Cell();
            var last = new LogUnit();
            last.cell = lastCell;
            unit.cell = unitCell;
            unit.AddFrom(last, bulge);
            var log = bulge.units.GetUnit<LogChannal>();
            Assert.NotNull(log);
            Assert.AreSame(bulge, log.bulge);
            Assert.AreSame(lastCell, bulge.from);
            Assert.AreSame(unitCell, bulge.to);
            Assert.AreEqual(1, last.outputs.Count);
            Assert.AreEqual(1, unit.inputs.Count);
            Assert.AreSame(log, last.outputs[0]);
            Assert.AreSame(log, unit.inputs[0]);
        }
    }
}
