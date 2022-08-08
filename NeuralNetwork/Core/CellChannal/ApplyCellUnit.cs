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
                tranning = value.units.AddUnit<TranningCellUnit>();
            }
        }
        private ActiveCellUnit active;
        private TranningCellUnit tranning;
        protected override void ActiveSelf()
        {
            active.bias += tranning.deltaBias;
        }
    }
}
