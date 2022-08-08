using System;

namespace NeuralNetwork
{
    public abstract class AChannal
    {
        public virtual Bulge bulge { get; set; }
        public ICellUnit from { get; private set; }
        public ICellUnit to { get; private set; }
        protected virtual bool activeInverse => false;
        public bool isActiveted { get; private set; }
        public void Active(ICellUnit cell)
        {
            if (isActiveted) return;
            isActiveted = true;
            ActiveInternal(cell);
        }
       
        protected virtual void ActiveSelf() { }

        public void Link(ICellUnit from, ICellUnit to)
        {
            this.from = from;
            this.to = to;
        }

        protected void ActiveCell(ICellUnit caller, ICellUnit cell)
        {
            if (caller != cell)
                cell.Active();
        }
        
        protected void ActiveInternal(ICellUnit cell)
        {
            var fromCell = from;
            var toCell = to;
            if (activeInverse)
            {
                fromCell = to;
                toCell = from;
            }
            ActiveCell(cell, fromCell);
            ActiveSelf();
            ActiveCell(cell, toCell);
        }
        public void Deactive()
        {
            if (!isActiveted) return;
            isActiveted = false;
            onDeactive();
        }
        protected virtual void onDeactive() 
        {
            from.Deactive();
            to.Deactive();
        }
        public abstract double GetValue();
        
    }
}
