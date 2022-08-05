using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class ValueCell : Cell
    {
        public ValueCell():base()
        {
            active = new InputActiveCellChannal { cell = this };
            tranning = null;
            apply = null;
        }
    }
}
