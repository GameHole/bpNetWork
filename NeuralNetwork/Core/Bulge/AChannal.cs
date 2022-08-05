using System;

namespace NeuralNetwork
{
    public abstract class AChannal
    {
        protected Bulge bulge;
        protected ACell from;
        protected ACell to;
        public void Init(Bulge bulge, ACell from, ACell to)
        {
            this.bulge = bulge;
            this.from = from;
            this.to = to;
        }
        public bool isActiveted { get; private set; }
        public void Active(ACell cell)
        {
            if (isActiveted) return;
            isActiveted = true;
            ActiveInternal(cell);
        }
       
        protected virtual void ActiveSelf() { }
        protected void ActiveCell(ACell caller, ACell cell)
        {
            if (caller != cell)
                ActiveCellAction(cell);
        }
 
        protected void ActiveInternal(ACell cell)
        {
            ActiveCell(cell, fromCell);
            ActiveSelf();
            ActiveCell(cell, toCell);
        }
        public void Reset()
        {
            if (!isActiveted) return;
            isActiveted = false;
            onReset();
        }
        protected virtual void onReset() 
        {
            from.Reset();
            to.Reset();
        }

        protected virtual ACell fromCell => from;
        protected virtual ACell toCell => to;
        protected abstract void ActiveCellAction(ACell cell);
        public abstract double GetValue();
        
    }
}
