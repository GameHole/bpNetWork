using System;

namespace NeuralNetwork
{
    public abstract class AChannal
    {
        protected Bulge bulge;
        protected Cell from;
        protected Cell to;
        public void Init(Bulge bulge, Cell from, Cell to)
        {
            this.bulge = bulge;
            this.from = from;
            this.to = to;
        }
        public bool isActiveted { get; private set; }
        public void Active(Cell cell)
        {
            if (isActiveted) return;
            isActiveted = true;
            ActiveInternal(cell);
        }
       
        protected virtual void ActiveSelf() { }
        protected void ActiveCell(Cell caller, Cell cell)
        {
            if (caller != cell)
                getCellChannal(cell)?.Active();
        }
        
        protected void ActiveInternal(Cell cell)
        {
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
        protected abstract ACellChannal getCellChannal(Cell cell);
        protected virtual Cell fromCell => from;
        protected virtual Cell toCell => to;
        public abstract double GetValue();
        
    }
}
