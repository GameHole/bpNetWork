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
            for (int i = 0; i < 3; i++)
            {
                var next = new Cell();
                bulges.Add(cell.AddInput(next));
                cell = next;
            }
            foreach (var item in cell.units)
            {
                cell.Active(item);
            }
            foreach (var item in bulges)
            {
                foreach (var channal in item.units)
                {
                    Assert.IsTrue(channal.isActiveted);
                }
            }
            cell.Deactive();
            int id = 0;
            foreach (var item in bulges)
            {
                
                foreach (var channal in item.units)
                {
                    Assert.IsFalse(channal.isActiveted,$"channal:{channal} id:{id}");
                }
                id++;
            }
        }
        [Test]
        public void testDeActiveOne()
        {
            var cells = TestCellActive.MakeCells(2);
            var bu = cells[0].AddInput(cells[1]);
            var log = bu.units.GetUnit<LogChannal>();
            cells[0].Active(typeof(LogChannal));
            Assert.IsTrue(log.isActiveted);
            cells[0].Deactive();
            Assert.IsFalse(log.isActiveted);
        }
    }
}
