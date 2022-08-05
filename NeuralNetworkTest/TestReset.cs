using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetwork;
namespace NeuralNetworkTest
{
    class TestReset
    {
        [Test]
        public void TestBulgeReset()
        {
            var cell = new Cell();
            List<Bulge> bulges = new List<Bulge>();
            for (int i = 0; i < 5; i++)
            {
                var next = new Cell();
                bulges.Add(cell.AddInput(next));
                cell = next;
            }
            cell.active.Active();
            cell.tranning.Active();
            cell.apply.Active();
            foreach (var item in bulges)
            {
                Assert.IsTrue(item.active.isActiveted);
                Assert.IsTrue(item.tranning.isActiveted);
                Assert.IsTrue(item.apply.isActiveted);
            }
            cell.Deactive();
            foreach (var item in bulges)
            {
                Assert.IsFalse(item.active.isActiveted);
                Assert.IsFalse(item.tranning.isActiveted);
                Assert.IsFalse(item.apply.isActiveted);
            }
        }
    }
}
