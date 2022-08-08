using System;

namespace NeuralNetwork
{
    public abstract class AChannal
    {
        public virtual Bulge bulge { get; set; }
        internal virtual bool activeInverse => false;
        public bool isActiveted { get; internal set; }
        public void Active(Cell cell)
        {
            bulge.Active(cell,this);
        }

        public virtual void ActiveSelf() { }

        public void Deactive()
        {
            bulge.Deactive(this);
        }
        public virtual void onDeactive() 
        {
           
        }
        public abstract double GetValue();
        
    }
}
