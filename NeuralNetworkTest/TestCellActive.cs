using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestCellActive
    {
        private CellDriver activator = new CellDriver();
        private void AssertCells(Cell input, Cell[] cells)
        {
            var logs = decCells(cells);
            activator.Active(input);
            for (int i = 0; i < logs.Length; i++)
            {
                Assert.AreEqual("active ",logs[i].log, $"index = {i}");
            }
        }

        private Cell[] makeCells(int count)
        {
            var cells = new Cell[count];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
                cells[i].active.bias = 1;
            }

            return cells;
        }
        private LogCell[] decCells(Cell[] cells)
        {
            var logs = new LogCell[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                logs[i] = new LogCell(cells[i]);
            }
            return logs;
        }

        [Test]
        public void testValueToCell()
        {
            var input = new ValueCell();
            var cells = makeCells(2);
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].AddInput(input);
            }
            AssertCells(input, cells);
        }

        [Test]
        public void testCellToValue()
        {
            var cell = new Cell();
            var cells = new ValueCell[2];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new ValueCell();
                cell.AddInput(cells[i]);
            }
            AssertCells(cells[0], cells);
        }
        [Test]
        public void testCellToCell()
        {
            Cell[] cells = makeCells(3);
            for (int i = 1; i < cells.Length; i++)
            {
                cells[i].AddInput(cells[0]);
            }
            AssertCells(cells[0], cells);
        }
        [Test]
        public void testCellToCellResult()
        {
            var cells = makeCells(3);
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].active.bias = 0;
            }
            cells[2].AddInput(cells[0]);
            cells[2].AddInput(cells[1]);
            foreach (var item in cells[2].inputs)
            {
                item.weight = 1;
            }
            AssertCells(cells[0], cells);
            var act = new Actviter();
            Assert.AreEqual(act.Actvite((1 * 0.5) * 2), cells[2].value);
        }
    }
}
