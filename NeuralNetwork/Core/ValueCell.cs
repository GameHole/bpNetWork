using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class ValueCell : Cell
    {
        public ValueCell()
        {
            units = new CellUnitContainer(this);
            units.AddUnit<InputActiveCellUnit>();
            units.AddUnit<NoneTranningUnit>();
            units.AddUnit<CountingCellUnit>();
            units.AddUnit<ApplyCellUnit>();
        }
    }
}
