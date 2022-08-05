using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Cell
    {
        public double value;
        public List<Bulge> inputs { get; private set; } = new List<Bulge>();
        public List<Bulge> outputs { get; private set; } = new List<Bulge>();
        public virtual Bulge AddInput(Cell cell)
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

        internal Actviter actviter = new Actviter();
        public Cell()
        {
            active = new ActiveCellChannal() { cell = this };
            counting = new CountingCellChannal() { cell = this };
            tranning = new TranningCellChannal() { cell = this, act = active, countting = counting };
            apply = new ApplyCellChannal() { cell = this };
        }

        public ActiveCellChannal active;
        public TranningCellChannal tranning;
        public ApplyCellChannal apply;
        public CountingCellChannal counting;
       
    }
}
