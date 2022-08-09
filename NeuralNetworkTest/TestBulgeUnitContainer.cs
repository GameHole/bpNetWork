using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestBulgeUnitContainer
    {
        BulgeUnitContainer cntr;
        Bulge bulge;
        [SetUp]
        public void SetUp()
        {
            bulge = new Bulge();
            cntr = new BulgeUnitContainer();
        }
        [Test]
        public void testAddMore()
        {
            var log = cntr.AddUnit<LogChannal>();
            Assert.NotNull(log);
            Assert.Throws<ArgumentException>(() =>
            {
                cntr.AddUnit<LogChannal>();
            });
            Assert.AreEqual(1, cntr.Count);
        }
        [Test]
        public void testGet()
        {
            Assert.AreEqual(0, cntr.Count);
            var unit = cntr.AddUnit<LogChannal>();
            Assert.AreSame(unit, cntr.GetUnit<LogChannal>());
        }
        [Test]
        public void testAddUnit()
        {
            var unit = cntr.AddUnit<LogChannal>();
            Assert.AreEqual(1, cntr.Count);
        }
    }
}
