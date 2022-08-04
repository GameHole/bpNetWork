using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestTranningCell
    {
        [Test]
        public void TestAddInput()
        {
            var t = new TranningCell();
            t.AddInput(new Cell());
            var ex = Assert.Throws<TranningInputException>(() => t.AddInput(new Cell()));
            Assert.AreEqual("TranningCell can only one input cell", ex.Message);
        }
    }
}
