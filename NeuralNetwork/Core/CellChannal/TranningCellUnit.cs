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
                active = value.units.GetUnit<ActiveCellUnit>();
                countting = value.units.GetUnit<CountingCellUnit>();
            }
        }
        private ActiveCellUnit active;
        private CountingCellUnit countting;

        public double deltaBias { get; set; }

        public override bool activeInverse => true;

        public override void ActiveSelf()
        {
            deltaBias = integrateInternal() * cell.actviter.Derivative(active.integrate());
            countting.counter.Count(deltaBias);
        }
        private double integrateInternal()
        {
            double sum = 0;
            foreach (var item in cell.outputs)
            {
                sum += item.units.GetUnit<TranningChannal>().GetValue();
            }
            return sum;
        }
    }
}
