using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestTranCellChannalReset
    {
        [Test]
        public void testTranReset()
        {
            var tran = new TranningCell();
            var cell = new Cell();
            var bulge = tran.AddInput(cell);
            tran.Tran();
            tran.Reset();
            Assert.AreEqual(0, bulge.units.GetUnit<CountingChannal>().counter.tranCount);
            Assert.AreEqual(0, cell.units.GetUnit<CountingChannal, Counter>().tranCount);
        }
    }
}
