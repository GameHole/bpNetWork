using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestNeuralNetwork
    {
        [Test]
        public void testNeuralNetwork()
        {
            var net = new NeuralNet();
            Assert.AreEqual(0, net.Input.Count);
            Assert.AreEqual(0, net.OutPut.Count);
        }
    }
}
