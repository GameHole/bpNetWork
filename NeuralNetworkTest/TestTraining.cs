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
            cell.units.GetUnit<ActiveChannal, ActiveAction>().bias = 1;
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
            Assert.AreEqual(LossToVHatDerivative, tranOut.units.GetUnit<TranningChannal, TranningBasic>().deltaBias, 1e-5);
            Assert.AreEqual(1, tranBulge.weight);
            //Assert.AreEqual(integration, cell.integrate());
            Assert.AreEqual(cellValue, cell.value, 1e-5);
            Assert.AreEqual(celDeltaBeias, cell.units.GetUnit<TranningChannal, TranningBasic>().deltaBias);

            for (int i = 0; i < inputBulgess.Length; i++)
            {
                var fromValue = 1;
                Assert.AreEqual(celDeltaBeias * fromValue, inputBulgess[i].units.GetUnit<TranningChannal>().deltaWeigth, 1e-5, $"i = {i}");
            }
            tranOut.Apply();
            Assert.AreEqual(1 + celDeltaBeias, cell.units.GetUnit<ActiveChannal, ActiveAction>().bias);
            for (int i = 0; i < inputBulgess.Length; i++)
            {
                Assert.AreEqual(0.5 + inputBulgess[i].units.GetUnit<TranningChannal>().deltaWeigth, inputBulgess[i].weight, 1e-5, $"i = {i}");
            }
        }
        [Test]
        public void TestRepeatTranning()
        {
            var tran = new TranningCell();
            var cell = new Cell();
            var log = new LogUnitAction();

            cell.units.Set(typeof(ActiveChannal), new CellUnit(typeof(ActiveChannal), log));
            var b = tran.AddInput(cell);
            for (int i = 0; i < 2; i++)
            {
                tran.Tran();
            }
            Assert.AreEqual("active active ", log.log);
            Assert.AreEqual(2, b.units.GetUnit<CountingChannal>().counter.tranCount);
            Assert.AreEqual(2, cell.units.GetUnit<CountingChannal, Counter>().tranCount);
        }
        [Test]
        public void testUnitUseAve()
        {
            var apply = new ApplyAction();
            var act = new ActiveAction();
            var counting = new Counter();
            apply.active = act;
            apply.counting = counting;
            counting.totalWidth = 5;
            counting.tranCount = 10;
            apply.ActiveSelf();
            Assert.AreEqual(0.5, act.bias,1e-5);
        }
        [Test]
        public void testChannalUseAve()
        {
            var bulge = new Bulge();
            var apply = new ApplyChannal();
            var counting = new CountingChannal();
            apply.bulge = bulge;
            for (int i = 0; i < 10; i++)
            {
                counting.counter.Count(i + 1);
            }
            apply.counting = counting;
            apply.ActiveSelf();
            Assert.AreEqual(5.5, bulge.weight, 1e-5);
        }
        [Test]
        public void testDifference()
        {
            var cell = new Cell();
            var tran = new TranningCell();
            tran.value = 2;
            tran.AddInput(cell);
            tran.Tran();
            Assert.AreEqual(0.5, cell.value);
            Assert.AreEqual(2, tran.value);
            Assert.AreEqual(2-0.5, tran.difference);
        }
    }
}
