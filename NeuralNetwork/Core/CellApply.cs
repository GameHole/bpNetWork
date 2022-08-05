using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    class CellApply : ACellChannal
    {
        protected override void ActiveSelf()
        {
            cell.bias += cell.deltaBias;
        }

        protected override AChannal getChannal(Bulge item)
        {
            return item.apply;
        }
    }
}
