using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class TranningCell:Cell
    {
        private Bulge input;
        protected override void AddUnits()
        {
            units.AddUnit<CellUnit<ActiveChannal,NoneUnitAction>>();
            units.AddUnit<CellUnit<TranningChannal, TranningBasic>>();
            units.AddUnit<CellUnit<ApplyChannal, NoneUnitAction>>();
            units.AddUnit<CellUnit<CountingChannal, Counter>>();
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
            Active(typeof(CountingChannal));
        }

        public double ieta;
        public void Tran()
        {
            Deactive();
            input.Active(this, typeof(ActiveChannal));
            input.weight = 1;
            units.GetUnit<CellUnit<TranningChannal, TranningBasic>>().action.deltaBias = ieta * (value - input.units.GetUnit<ActiveChannal>().GetValue());
            Active(typeof(TranningChannal));
        }

        public void Apply()
        {
            Active(typeof(ApplyChannal));
        }
    }
}
