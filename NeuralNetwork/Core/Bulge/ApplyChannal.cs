using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ApplyChannal : AChannal
    {
        public override Bulge bulge 
        { 
            get => base.bulge;
            set
            {
                base.bulge = value;
                counting = value.units.GetUnit<CountingChannal>();
            }
        }
        public CountingChannal counting;

        public override void ActiveSelf()
        {
            bulge.weight += counting.GetValue();
        }
    }
}
