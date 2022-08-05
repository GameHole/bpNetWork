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
        [SetUp]
        public void SetUp()
        {
            channal = new LogChannal();
        }
        [Test]
        public void TestActive()
        {
            Assert.IsFalse(channal.isActiveted);
            for (int i = 0; i < 2; i++)
            {
                channal.Active(null);
            }
            Assert.IsTrue(channal.isActiveted);
            Assert.AreEqual("active", channal.log);
        }
        [Test]
        public void TestReset()
        {
            channal.Active(null);
            for (int i = 0; i < 2; i++)
            {
                channal.Reset();
            }
            Assert.IsFalse(channal.isActiveted);
            Assert.AreEqual("activereset", channal.log);
        }
    }
}
