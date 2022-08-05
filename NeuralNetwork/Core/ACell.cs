using System.Collections.Generic;

namespace NeuralNetwork
{
    public abstract class ACell
    {
        public double value;
        public List<Bulge> inputs { get; private set; } = new List<Bulge>();
        public List<Bulge> outputs { get; private set; } = new List<Bulge>();
        protected Bulge AddInput(ACell cell)
        {
            var bulge = new Bulge(cell, this);
            cell.outputs.Add(bulge);
            inputs.Add(bulge);
            return bulge;
        }

        internal void ActiveBulges(List<Bulge> bulges)
        {
            foreach (var item in bulges)
            {
                item.active.Active(this);
            }
        }
        public void Reset()
        {
            foreach (var item in inputs)
            {
                item.Reset();
            }
            foreach (var item in outputs)
            {
                item.Reset();
            }
        }
    }
}
