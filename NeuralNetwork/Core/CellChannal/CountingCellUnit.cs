using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CountingCellUnit : ACellUnit<CountingChannal>
    {
        public int tranCount;
        protected override void ActiveSelf()
        {
            tranCount = 0;
        }
    }
}
