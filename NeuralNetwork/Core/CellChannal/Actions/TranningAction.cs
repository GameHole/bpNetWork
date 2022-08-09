using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TranningAction:TranningBasic
    {
        public override Cell cell
        {
            get => base.cell;
            set
            {
                base.cell = value;
                active = value.units.GetUnit<CellUnit<ActiveChannal, ActiveAction>>().action;
                countting = value.units.GetUnit<CellUnit<CountingChannal, Counter>>().action;
            }
        }
        private ActiveAction active;
        private Counter countting;

        public override void ActiveSelf()
        {
            deltaBias = integrateInternal() * cell.actviter.Derivative(active.integrate());
            countting.Count(deltaBias);
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
