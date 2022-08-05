using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    abstract class ACellChannal
    {
        public Cell cell;
        public virtual double integrate()
        {
            double sum = 0;
            foreach (var item in fromBulges)
            {
                var channal = getChannal(item);
                sum += channal.GetValue();
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
                var channal = getChannal(item);
                channal.Active(cell);
            }
        }

        protected virtual List<Bulge> toBulges => cell.outputs;
        protected virtual List<Bulge> fromBulges => cell.inputs;
        protected abstract void ActiveSelf();
        protected abstract AChannal getChannal(Bulge item);
    }
}
