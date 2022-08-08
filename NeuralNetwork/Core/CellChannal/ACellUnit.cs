using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public abstract class ACellUnit<T>:ICellUnit where T : AChannal, new()
    {
        public virtual Cell cell { get; set; }
        public List<T> inputs { get; private set; } = new List<T>();
        public List<T> outputs { get; private set; } = new List<T>();
        protected virtual bool activeInverse => false;

        public Type ChannalType => typeof(T);

        public void AddFrom(ICellUnit from, Bulge bulge)
        {
            var channal = bulge.units.AddUnit<T>();
            var cell = from as ACellUnit<T>;
            bulge.Link(from.cell, this.cell);
            cell.outputs.Add(channal);
            inputs.Add(channal);
        }

        public void Deactive()
        {
            foreach (var item in inputs)
            {
                item.Deactive();
            }
            foreach (var item in outputs)
            {
                item.Deactive();
            }
        }
        public virtual double integrate()
        {
            double sum = 0;
            var from = inputs;
            if (activeInverse)
                from = outputs;
            foreach (var item in from)
            {
                sum += item.GetValue();
            }
            return sum;
        }
        public virtual void Active()
        {
            var from = inputs;
            var to = outputs;
            if (activeInverse)
            {
                from = outputs;
                to = inputs;
            }
            ActiveBulges(from);
            ActiveSelf();
            ActiveBulges(to);
        }
        internal void ActiveBulges(List<T> bulges)
        {
            foreach (var item in bulges)
            {
                item.Active(this.cell);
            }
        }
        protected abstract void ActiveSelf();
    }
}
