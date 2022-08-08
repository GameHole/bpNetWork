using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public abstract class ACellUnit<T>:ICellUnit where T : AChannal, new()
    {
        public virtual bool activeInverse => false;
        public abstract void ActiveSelf();


        public virtual Cell cell { get; set; }

        public Type ChannalType => typeof(T);

        public void AddChannal(Bulge bulge)
        {
            bulge.units.AddUnit<T>();
        }
    }
}
