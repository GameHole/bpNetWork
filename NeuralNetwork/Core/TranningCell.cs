using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class TranningCell:Cell
    {
        private Bulge input;
        public TranningCell()
        {
            units = new CellUnitContainer(this);
            units.AddUnit<InputActiveCellUnit>();
            units.AddUnit<NoneTranningUnit>();
            units.AddUnit<ApplyCellUnit>();
            units.AddUnit<CountingCellUnit>();
        }

        

        public override Bulge AddInput(Cell cell)
        {
            if (input!=null)
                throw new TranningInputException("TranningCell can only one input cell");
            var item = base.AddInput(cell);
            input = item;
            return item;
        }

        public void Reset()
        {
            Active(units.GetUnit<CountingCellUnit>());
        }

        public double ieta;
        public void Tran()
        {
            Deactive();
            Active(units.GetUnit<InputActiveCellUnit>());
            input.weight = 1;
            units.GetUnit<NoneTranningUnit>().deltaBias = ieta * (value - input.units.GetUnit<ActiveChannal>().GetValue());
            Active(units.GetUnit<NoneTranningUnit>());
        }

        public void Apply()
        {
            Active(units.GetUnit<ApplyCellUnit>());
        }
    }
}
