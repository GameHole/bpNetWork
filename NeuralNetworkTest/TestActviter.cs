using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestActviter
    {
        [Test]
        public void Test()
        {
            var act = new Actviter();
            Assert.AreEqual(1 / (1 + Math.Pow(Math.E, -1)), act.Actvite(1));
            var fu = act.Actvite(2);
            Assert.AreEqual(fu * (1 - fu), act.Derivative(2));
        }
    }
}
