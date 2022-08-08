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
            var cells = new Cell[2];
            for (int i = 0; i < cells.Length; i++)
            {
                var cel = new Cell();
                cel.units.Clear();
                cel.units.AddUnit<LogUnit>();
                cells[i] = cel;
            }
            var bu = cells[0].AddInput(cells[1]);
            var log = bu.units.GetUnit<LogChannal>();
            cells[0].units.GetUnit<LogUnit>().Active();
            Assert.IsTrue(log.isActiveted);
            cells[0].Deactive();
            Assert.IsFalse(log.isActiveted);
        }
    }
}
