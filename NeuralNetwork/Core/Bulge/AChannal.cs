using System;

namespace NeuralNetwork
{
    public abstract class AChannal
    {
        public Bulge bulge;
        private bool isAccessed;
        internal void Access(ACell cell)
        {
            if (isAccessed) return;
            isAccessed = true;
            AccessInternal(cell);
        }
        protected void Notify(ACell caller, ACell cell)
        {
            if (caller != cell)
                NotifyAction(cell);
        }
        protected void NotifyTo(ACell cell)
        {
            Notify(cell, bulge.to);
        }

        protected void NotifyFrom(ACell cell)
        {
            Notify(cell, bulge.from);
        }
        protected abstract void NotifyAction(ACell cell);
        protected abstract void AccessInternal(ACell cell);
    }
}
