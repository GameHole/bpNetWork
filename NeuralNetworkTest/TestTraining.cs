using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestTraining
    {
        [Test]
        public void testTrainingOneCell()
        {
            var actor = new Actviter();
            var inputBulgess = new Bulge[2];
            var cell = new Cell();
            cell.active.bias = 1;
            var tranOut = new TranningCell();
            double integration = 0;
            for (int i = 0; i < inputBulgess.Length; i++)
            {
                var input = new ValueCell() { value = 1 };
                var bulge = cell.AddInput(input);
                bulge.weight = 0.5;
                inputBulgess[i] = bulge;
                integration += 1 * 0.5;
            }
            var tranBulge = tranOut.AddInput(cell);
            tranOut.value = 1;
            tranOut.ieta = 0.8;
            tranOut.Tran();
            integration += 1;
            var cellValue = actor.Actvite(integration);
            var LossToVHatDerivative = 0.8 * (1 - cellValue);
            var LossToCellBeiasDerivative = 1;
            var celDeltaBeias = LossToVHatDerivative * LossToCellBeiasDerivative * actor.Derivative(integration);
            Assert.AreEqual(LossToVHatDerivative, tranOut.tranning.deltaBias, 1e-5);
            Assert.AreEqual(1, tranBulge.weight);
            //Assert.AreEqual(integration, cell.integrate());
            Assert.AreEqual(cellValue, cell.value, 1e-5);
            Assert.AreEqual(celDeltaBeias, cell.tranning.deltaBias);

            for (int i = 0; i < inputBulgess.Length; i++)
            {
                var fromValue = 1;
                Assert.AreEqual(celDeltaBeias * fromValue, inputBulgess[i].tranning.deltaWeigth, 1e-5, $"i = {i}");
            }
            tranOut.Apply();
            Assert.AreEqual(1 + celDeltaBeias, cell.active.bias);
            for (int i = 0; i < inputBulgess.Length; i++)
            {
                Assert.AreEqual(0.5 + inputBulgess[i].tranning.deltaWeigth, inputBulgess[i].weight, 1e-5, $"i = {i}");
            }
        }
        [Test]
        public void TestRepeatTranning()
        {
            var tran = new TranningCell();
            var cell = new Cell();
            var log = new LogCell(cell);
            var b = tran.AddInput(cell);
            for (int i = 0; i < 2; i++)
            {
                tran.Tran();
            }
            Assert.AreEqual("active active ", log.log);
            Assert.AreEqual(2, b.counting.tranCount);
            Assert.AreEqual(2, cell.counting.tranCount);
        }
    }
}
