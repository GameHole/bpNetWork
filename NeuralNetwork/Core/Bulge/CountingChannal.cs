using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CountingChannal : AChannal
    {
        public int tranCount;
        public override double GetValue()
        {
            throw new NotImplementedException();
        }

        protected override void ActiveSelf()
        {
            tranCount = 0;
        }
    }
}
