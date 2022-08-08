using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Cell
    {
        public double value;
        public CellUnitContainer units { get; protected set; }
        public virtual Bulge AddInput(Cell cell)
        {
            var bulge = new Bulge();
            foreach (var item in units)
            {
                var unit = cell.units.GetUnit(item.ChannalType);
                if (unit != null)
                {
                    item.AddFrom(unit, bulge);
                }
            }
            return bulge;
        }

        public void Deactive()
        {
            foreach (var item in units)
            {
                item.Deactive();
            }
        }

        internal Actviter actviter = new Actviter();
        public Cell()
        {
            units = new CellUnitContainer(this);
            units.AddUnit<ActiveCellUnit>();
            units.AddUnit<CountingCellUnit>();
            units.AddUnit<TranningCellUnit>();
            units.AddUnit<ApplyCellUnit>();
        }
    }
}
