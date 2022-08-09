using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ApplyAction:AUnitAction
    {
        public override Cell cell
        {
            get => base.cell;
            set
            {
                base.cell = value;
                active = value.units.GetUnit<CellUnit<ActiveChannal, ActiveAction>>().action;
                counting = value.units.GetUnit<CellUnit<CountingChannal, Counter>>().action;
            }
        }

        public Counter counting;

        public ActiveAction active;
        public override void ActiveSelf()
        {
            active.bias += counting.GetValue();
        }
    }
}
