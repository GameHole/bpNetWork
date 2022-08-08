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
            units.GetUnit<CountingCellUnit>().Active();
        }

        public double ieta;
        public void Tran()
        {
            Deactive();
            units.GetUnit<InputActiveCellUnit>().Active();
            input.weight = 1;
            units.GetUnit<NoneTranningUnit>().deltaBias = ieta * (value - input.units.GetUnit<ActiveChannal>().GetValue());
            units.GetUnit<NoneTranningUnit>().Active();
        }

        public void Apply()
        {
            units.GetUnit<ApplyCellUnit>().Active();
        }
    }
}
