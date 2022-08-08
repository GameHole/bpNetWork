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
        public BulgeUnitContainer units { get; }
        public Bulge()
        {
            units = new BulgeUnitContainer(this);
        }
        public void Link(Cell from, Cell to)
        {
           this.from = from;
           this.to = to;
        }
        public void Active(Cell cell, AChannal channal)
        {
            if (channal.isActiveted) return;
            channal.isActiveted = true;
            ActiveInternal(cell, channal);
        }
        private void ActiveCell(Cell caller, Cell cell, AChannal channal)
        {
            if (caller != cell)
                cell.units.GetUnit(channal.GetType()).Active();
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
            channal.onDeactive();
            Deactive();
        }
        public void Deactive()
        {
            from.Deactive();
            to.Deactive();
        }
    }
}
