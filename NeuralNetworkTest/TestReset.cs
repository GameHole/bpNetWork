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
        public void TestBulgeDeactive()
        {
            var cell = new Cell();
            List<Bulge> bulges = new List<Bulge>();
            for (int i = 0; i < 5; i++)
            {
                var next = new Cell();
                bulges.Add(cell.AddInput(next));
                cell = next;
            }
            foreach (var item in cell.units)
            {
                item.Active();
            }
            foreach (var item in bulges)
            {
                foreach (var channal in item.units)
                {
                    Assert.IsTrue(channal.isActiveted);
                }
            }
            cell.Deactive();
            foreach (var item in bulges)
            {
                foreach (var channal in item.units)
                {
                    Assert.IsFalse(channal.isActiveted);
                }
            }
        }
    }
}
