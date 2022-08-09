using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Counter:AUnitAction
    {
        public int tranCount;
        public double totalWidth;

        public double GetValue()
        {
            return totalWidth / tranCount;
        }

        public void Reset()
        {
            tranCount = 0;
            totalWidth = 0;
        }

        public void Count(double v)
        {
            tranCount++;
            totalWidth += v;
        }

        public override void ActiveSelf()
        {
            Reset();
        }
    }
}
