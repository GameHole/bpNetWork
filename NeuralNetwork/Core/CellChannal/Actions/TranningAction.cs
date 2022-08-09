using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TranningAction:TranningBasic
    {
        public Cell cell;
        public ActiveAction active;
        public Counter countting;

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
