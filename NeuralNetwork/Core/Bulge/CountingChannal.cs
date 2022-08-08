using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CountingChannal : AChannal
    {
        public Counter counter = new Counter();

        public int tranCount { get => counter.tranCount; }

        public override double GetValue()
        {
            return counter.GetValue();
        }

        public override void ActiveSelf()
        {
            counter.Reset();
        }

        public void Count(double v)
        {
            counter.Count(v);
        }
    }
}
