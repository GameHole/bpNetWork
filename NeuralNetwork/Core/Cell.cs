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
            bulge.Link(cell, this);
            cell.outputs.Add(bulge);
            inputs.Add(bulge);
            return bulge;
        }
        public virtual void Active(CellUnit unit)
        {
            var from = inputs;
            var to = outputs;
            if (unit.activeInverse)
            {
                from = outputs;
                to = inputs;
            }
            ActiveBulges(from,unit.ChannalType);
            unit.Action.ActiveSelf();
            ActiveBulges(to, unit.ChannalType);
        }
        public void Active(Type channalType)
        {
            var unit = units.Get(channalType);
            if (unit != null)
                Active(unit);
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
        private void DeactiveInternal(CellUnit unit)
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
            units = new CellUnitContainer();
            AddUnits();
            
        }

        protected virtual void AddUnits()
        {
            var act = new ActiveAction();
            var counter = new Counter();
            var tran = new TranningAction();
            var apply = new ApplyAction();
            act.cell = this;
            tran.cell = this;
            apply.active = act;
            apply.counting = counter;
            tran.active = act;
            tran.countting = counter;
            units.AddUnit<ActiveChannal>(act);
            units.AddUnit<CountingChannal>(counter);
            units.AddUnit<TranningChannal>(tran, true);
            units.AddUnit<ApplyChannal>(apply);
        }
    }
}
