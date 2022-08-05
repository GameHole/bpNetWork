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

        protected override ACellChannal getCellChannal(Cell cell)
        {
            return cell.counting;
        }
        protected override void ActiveSelf()
        {
            tranCount = 0;
        }
    }
}
