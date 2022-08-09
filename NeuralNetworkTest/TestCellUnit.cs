using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestCellUnit
    {
        CellUnit<LogChannal, LogUnitAction> unit;
        [SetUp]
        public void SetUp()
        {
            unit = new CellUnit<LogChannal, LogUnitAction>(new LogUnitAction(),true);
        }
       
        [Test]
        public void testCellUnit()
        {
            Assert.IsTrue(unit.activeInverse);
            Assert.AreSame(typeof(LogChannal),unit.ChannalType);
        }
    }
}
