using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public abstract class ACellChannal
    {
        public Cell cell;

        protected virtual List<Bulge> toBulges => cell.outputs;
        protected virtual List<Bulge> fromBulges => cell.inputs;
        public virtual double integrate()
        {
            double sum = 0;
            foreach (var item in fromBulges)
            {
                sum += getChannal(item).GetValue();
            }
            return sum;
        }
        public virtual void Active()
        {
            ActiveBulges(fromBulges);
            ActiveSelf();
            ActiveBulges(toBulges);
        }
        internal void ActiveBulges(List<Bulge> bulges)
        {
            foreach (var item in bulges)
            {
                getChannal(item).Active(cell);
            }
        }
        protected abstract void ActiveSelf();
        protected abstract AChannal getChannal(Bulge item);
    }
}
