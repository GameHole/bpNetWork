using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CountingCellChannal : ACellChannal
    {
        public int tranCount;
        protected override void ActiveSelf()
        {
            tranCount = 0;
        }

        protected override AChannal getChannal(Bulge item)
        {
            return item.counting;
        }
    }
}
