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

        protected void ActiveBulges(List<Bulge> bulges)
        {
            foreach (var item in bulges)
            {
                item.active.Access(this);
            }
        }
        protected void TranBulges(List<Bulge> bulges)
        {
            foreach (var item in bulges)
            {
                item.tranning.Access(this);
            }
        }
    }
}
