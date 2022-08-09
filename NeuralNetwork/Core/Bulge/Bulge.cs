using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Bulge
    {
        public double weight;
        public Cell from { get; set; }
        public Cell to { get; set; }
        public BulgeUnitContainer units { get; } = new BulgeUnitContainer();
        private void InitUnits(CellUnitContainer cntr)
        {
            foreach (var item in cntr)
            {
                units.AddUnit(item.ChannalType, item.activeInverse);
            }
            foreach (var item in units)
            {
                item.bulge = this;
            }
        }
        public void Link(Cell from, Cell to)
        {
            this.from = from;
            this.to = to;
            InitUnits(to.units);
        }
        public void Active(Cell cell, AChannal channal)
        {
            if (channal.isActiveted) return;
            channal.isActiveted = true;
            ActiveInternal(cell, channal);
        }
        internal void Active(Cell cell, Type channalType)
        {
            Active(cell, units.Get(channalType));
        }
        private void ActiveCell(Cell caller, Cell cell, AChannal channal)
        {
            if (cell != null && caller != cell)
                cell.Active(channal.GetType());
        }
        internal void ActiveInternal(Cell cell,AChannal channal)
        {
            var fromCell = from;
            var toCell = to;
            if (channal.activeInverse)
            {
                fromCell = to;
                toCell = from;
            }
            ActiveCell(cell, fromCell, channal);
            channal.ActiveSelf();
            ActiveCell(cell, toCell, channal);
        }
        public void Deactive(AChannal channal)
        {
            if (!channal.isActiveted) return;
            channal.isActiveted = false;
            Deactive();
        }
        private void Deactive()
        {
            from.Deactive();
            to.Deactive();
        }
    }
}
