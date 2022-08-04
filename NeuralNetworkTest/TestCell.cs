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
            cell = new Cell() { bias = 1 };
            actviter = new Actviter();
        }
        [Test]
        public void testCell()
        {
            Assert.AreEqual(1, cell.bias);
            Assert.AreEqual(0, cell.inputs.Count);
            Assert.AreEqual(0,cell.outputs.Count);
        }
        [Test]
        public void testInitCell()
        {
            cell = new Cell();
            Assert.GreaterOrEqual(cell.bias,0);
            Assert.LessOrEqual(cell.bias, 1);
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
            cell.Active();
            Assert.AreEqual(actviter.Actvite(integration), cell.value, 1e-5);
        }
    }
}
