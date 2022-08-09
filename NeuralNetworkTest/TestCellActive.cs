using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestCellActive
    {
        private Cell[] MakeCells(int count)
        {
            var cells = new Cell[count];
            for (int i = 0; i < cells.Length; i++)
            {
                var cell = new Cell();
                cell.units.Clear();
                cell.units.AddUnit<LogUnit>();
                cells[i] = cell;
            }
            return cells;
        }

        private void AssertActive(Cell[] cells, List<Bulge> bulges)
        {
            Assert.Greater(bulges.Count, 0);
            cells[0].Active(typeof(LogChannal));
            for (int i = 0; i < bulges.Count; i++)
            {
                Assert.IsTrue(bulges[i].units.GetUnit<LogChannal>().isActiveted,$"id = {i}");
            }
            for (int i = 0; i < cells.Length; i++)
            {
                Assert.IsTrue(cells[i].units.GetUnit<LogUnit>().isActive);
            }
        }

        [Test]
        public void testCellToCell()
        {
            var cells = MakeCells(10);
            var bulges = new List<Bulge>();
            for (int i = 0; i < cells.Length-1; i++)
            {
                bulges.Add(cells[i+1].AddInput(cells[i]));
            }
            AssertActive(cells, bulges);
        }

        [Test]
        public void testMutiInput()
        {
            var cells = MakeCells(3);
            var bulges = new List<Bulge>();
            for (int i = 1; i < cells.Length; i++)
            {
                bulges.Add(cells[0].AddInput(cells[i]));
            }
            AssertActive(cells, bulges);
        }

        [Test]
        public void testMutiOutput()
        {
            var cells = MakeCells(3);
            var bulges = new List<Bulge>();
            for (int i = 1; i < cells.Length; i++)
            {
                bulges.Add(cells[i].AddInput(cells[0]));
            }
            AssertActive(cells, bulges);
        }
    }
}
