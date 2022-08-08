using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CountingChannal : AChannal
    {
        public Counter counter = new Counter();
        public double GetValue()
        {
            return counter.GetValue();
        }

        public override void ActiveSelf()
        {
            counter.Reset();
        }
    }
}
