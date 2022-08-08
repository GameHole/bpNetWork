using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Cell
    {
        public double value;
        public List<Bulge> inputs { get; private set; } = new List<Bulge>();
        public List<Bulge> outputs { get; private set; } = new List<Bulge>();
        public CellUnitContainer units { get; protected set; }
        public virtual Bulge AddInput(Cell cell)
        {
            var bulge = new Bulge();
            foreach (var item in units)
            {
                var unit = cell.units.GetUnit(item.ChannalType);
                if (unit != null)
                {
                    item.AddChannal(bulge);
                }
            }
            bulge.Link(cell, this);
            cell.outputs.Add(bulge);
            inputs.Add(bulge);
            return bulge;
        }
        public void Active(ICellUnit unit)
        {
            var from = inputs;
            var to = outputs;
            if (unit.activeInverse)
            {
                from = outputs;
                to = inputs;
            }
            ActiveBulges(from,unit.ChannalType);
            unit.ActiveSelf();
            ActiveBulges(to, unit.ChannalType);
        }
        internal void Active(Type channalType)
        {
            Active(units.Get(channalType));
        }
        private void ActiveBulges(List<Bulge> bulges, Type channalType)
        {
            foreach (var item in bulges)
            {
                item.Active(this, channalType);
            }
        }
        public void Deactive()
        {
            foreach (var item in units)
            {
                DeactiveInternal(item);
            }
        }
        private void DeactiveInternal(ICellUnit unit)
        {
            foreach (var item in inputs)
            {
                item.Deactive(item.units.Get(unit.ChannalType));
            }
            foreach (var item in outputs)
            {
                item.Deactive(item.units.Get(unit.ChannalType));
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
