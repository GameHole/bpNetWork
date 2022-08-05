using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ApplyCellChannal : ACellChannal
    {
        protected override void ActiveSelf()
        {
            cell.active.bias += cell.tranning.deltaBias;
        }

        protected override AChannal getChannal(Bulge item)
        {
            return item.apply;
        }
    }
}
