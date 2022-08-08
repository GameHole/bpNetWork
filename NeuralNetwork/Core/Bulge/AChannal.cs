using System;

namespace NeuralNetwork
{
    public abstract class AChannal
    {
        internal virtual bool activeInverse => false;
        public virtual void ActiveSelf() { }

        public virtual Bulge bulge { get; set; }
       
        public bool isActiveted { get; internal set; }

    }
}
