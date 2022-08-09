using NeuralNetwork;
using NUnit.Framework;
using System;

namespace NeuralNetworkTest
{
    class TestCell
    {
        Cell cell;
        Actviter actviter;
        [SetUp]
        public void SetUp()
        {
            cell = new Cell();
            cell.units.GetUnit<CellUnit<ActiveChannal, ActiveAction>>().action.bias = 1;
            actviter = new Actviter();
        }
        [Test]
        public void testCell()
        {
            Assert.AreEqual(1, cell.units.GetUnit<CellUnit<ActiveChannal, ActiveAction>>().action.bias);
        }
        

        [Test]
        public void testAddInput()
        {
            var value = new ValueCell() { value = 1.5f };
            var bulge = cell.AddInput(value);
            var act = bulge.units.GetUnit<ActiveChannal>();
            Assert.NotNull(act);
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
        public void testMakeChannal()
        {
            var bulge = new Bulge();
            cell.AddChannal(bulge, typeof(LogChannal));
            var log = bulge.units.GetUnit<LogChannal>();
            Assert.NotNull(log);
            Assert.AreSame(bulge, log.bulge);
        }
        [Test]
        public void testInitCell()
        {
            cell = new Cell();
            Assert.GreaterOrEqual(cell.units.GetUnit<CellUnit<ActiveChannal, ActiveAction>>().action.bias,0);
            Assert.LessOrEqual(cell.units.GetUnit<CellUnit<ActiveChannal, ActiveAction>>().action.bias, 1);
        }
        [Test]
        public void testCellUnit()
        {
            cell.units.Clear();
            var unit = new CellUnit<LogChannal, LogUnit>(new LogUnit());
            cell.units.AddUnit(unit);
            var getted = cell.units.GetUnit(typeof(LogChannal));
            Assert.NotNull(getted);
            Assert.AreSame(unit, getted);
        }
        [Test]
        public void testIntegration()
        {
            for (int i = 0; i < 3; i++)
            {
                var idx = i + 1;
                var bulg = cell.AddInput(new ValueCell { value= idx });
                bulg.weight = 0.1 * idx;
            }
            var integration = 1 * 0.1 + 2 * 0.2 + 3 * 0.3 + 1;
            var act = cell.units.GetUnit<CellUnit<ActiveChannal, ActiveAction>>();
            Assert.AreEqual(integration, act.action.integrate(), 1e-5);
            cell.Active(act);
            Assert.AreEqual(actviter.Actvite(integration), cell.value, 1e-5);
        }
    }
}
