using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ApplyCellUnit : ACellUnit<ApplyChannal>
    {
        public override Cell cell
        {
            get => base.cell;
            set
            {
                base.cell = value;
                active = value.units.GetUnit<ActiveCellUnit>();
                counting = value.units.GetUnit<CountingCellUnit>();
            }
        }

        public CountingCellUnit counting;

        public ActiveCellUnit active;
        public override void ActiveSelf()
        {
            active.bias += counting.GetValue();
        }
    }
}
