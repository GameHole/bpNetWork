using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class ValueCell : Cell
    {
        protected override void AddUnits()
        {
            units.AddUnit<InputActiveCellUnit>();
        }
    }
}
