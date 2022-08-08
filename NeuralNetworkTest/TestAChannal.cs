using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestAChannal
    {
        LogChannal channal;
        Bulge bulge;
        [SetUp]
        public void SetUp()
        {
            channal = new LogChannal();
            bulge = new Bulge();
            var cell = new Cell();
            cell.units.AddUnit<LogUnit>();
            bulge.from = cell;
            bulge.to = cell;
            channal.bulge = bulge;
        }
        [Test]
        public void TestActive()
        {
            Assert.IsFalse(channal.isActiveted);
            for (int i = 0; i < 2; i++)
            {
                bulge.Active(null,channal);
            }
            Assert.IsTrue(channal.isActiveted);
            Assert.AreEqual("active", channal.log);
        }
        [Test]
        public void TestReset()
        {
            bulge.Active(null, channal);
            for (int i = 0; i < 2; i++)
            {
                bulge.Deactive(channal);
            }
            Assert.IsFalse(channal.isActiveted);
        }
    }
}
