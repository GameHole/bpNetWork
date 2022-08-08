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
            cell.units.GetUnit<ActiveCellUnit>().bias = 1;
            actviter = new Actviter();
        }
        [Test]
        public void testCell()
        {
            Assert.AreEqual(1, cell.units.GetUnit<ActiveCellUnit>().bias);
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
        }
        [Test]
        public void testInitCell()
        {
            cell = new Cell();
            Assert.GreaterOrEqual(cell.units.GetUnit<ActiveCellUnit>().bias,0);
            Assert.LessOrEqual(cell.units.GetUnit<ActiveCellUnit>().bias, 1);
        }
        [Test]
        public void testCellUnit()
        {
            cell.units.Clear();
            var unit = cell.units.AddUnit<LogUnit>();
            var getted = cell.units.GetUnit(unit.ChannalType);
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
            var act = cell.units.GetUnit<ActiveCellUnit>();
            Assert.AreEqual(integration, act.integrate(), 1e-5);
            act.Active();
            Assert.AreEqual(actviter.Actvite(integration), cell.value, 1e-5);
        }
    }
}
