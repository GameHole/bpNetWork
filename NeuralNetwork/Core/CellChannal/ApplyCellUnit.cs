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
                active = value.units.AddUnit<ActiveCellUnit>();
                counting = value.units.AddUnit<CountingCellUnit>();
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
