using NeuralNetwork;
using NUnit.Framework;
using System;

namespace NeuralNetworkTest
{
    class TestCell
    {
        Cell cell;
        Actviter actviter;
        ActiveAction act;
        [SetUp]
        public void SetUp()
        {
            cell = new Cell();
            act = cell.units.GetUnit<ActiveChannal, ActiveAction>();
            actviter = new Actviter();
        }

        [Test]
        public void testAddInput()
        {
            var value = new ValueCell() { value = 1.5f };
            var bulge = cell.AddInput(value);
            var act = bulge.units.GetUnit<ActiveChannal>();
            Assert.NotNull(act);
            Assert.AreSame(bulge, act.bulge);
            Assert.AreSame(value, bulge.from);
            Assert.AreSame(cell, bulge.to);
            Assert.AreSame(value, bulge.from);
            Assert.AreSame(cell, bulge.to);
            Assert.AreEqual(1, value.outputs.Count);
            Assert.AreEqual(1, cell.inputs.Count);
            Assert.AreSame(bulge, value.outputs[0]);
            Assert.AreSame(bulge, cell.inputs[0]);
        }
        [Test]
        public void testSyncDirection()
        {
            var bulge = cell.AddInput(new Cell());
            foreach (var item in bulge.units)
            {
                Assert.AreEqual(item.activeInverse, cell.units.Get(item.GetType()).activeInverse);
            }
        }
        [Test]
        public void testInitCell()
        {
            Assert.GreaterOrEqual(act.bias,0);
            Assert.LessOrEqual(act.bias, 1);
        }
        [Test]
        public void testCellUnit()
        {
            cell.units.Clear();
            CellUnit unit = NewLogUnit();
            cell.units.AddUnit(unit);
            var getted = cell.units.GetUnit(typeof(LogChannal));
            Assert.NotNull(getted);
            Assert.AreSame(unit, getted);
        }

        public static CellUnit NewLogUnit()
        {
            return new CellUnit(typeof(LogChannal), new LogUnit());
        }

        [Test]
        public void testIntegration()
        {
            act.bias = 1;
            for (int i = 0; i < 3; i++)
            {
                var idx = i + 1;
                var bulg = cell.AddInput(new ValueCell { value= idx });
                bulg.weight = 0.1 * idx;
            }
            var integration = 1 * 0.1 + 2 * 0.2 + 3 * 0.3 + 1;
            Assert.AreEqual(integration, act.integrate(), 1e-5);
            cell.Active(typeof(ActiveChannal));
            Assert.AreEqual(actviter.Actvite(integration), cell.value, 1e-5);
        }
    }
}
