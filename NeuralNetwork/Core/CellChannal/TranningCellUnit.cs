using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TranningCellUnit : ACellUnit<TranningChannal>
    {
        public override Cell cell
        {
            get => base.cell; 
            set
            {
                base.cell = value;
                active = value.units.AddUnit<ActiveCellUnit>();
                countting = value.units.AddUnit<CountingCellUnit>();
            }
        }
        private ActiveCellUnit active;
        private CountingCellUnit countting;

        public double deltaBias { get; set; }

        protected override bool activeInverse => true;

        protected override void ActiveSelf()
        {
            deltaBias = integrate() * cell.actviter.Derivative(active.integrate());
            countting.tranCount++;
            countting.totalWidth += deltaBias;
        }
    }
}
