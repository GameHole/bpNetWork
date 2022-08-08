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
                counting = value.units.AddUnit<CountingChannal>();
            }
        }
        public CountingChannal counting;

        public override double GetValue()
        {
            throw new NotImplementedException();
        }
        public override void ActiveSelf()
        {
            bulge.weight += counting.GetValue();
        }
    }
}
