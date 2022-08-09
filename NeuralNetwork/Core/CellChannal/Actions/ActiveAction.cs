using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ActiveAction : AUnitAction
    {
        public double bias;
        public override void ActiveSelf()
        {
            cell.value = cell.actviter.Actvite(integrate());
        }
        public double integrate()
        {
            double sum = 0;
            foreach (var item in cell.inputs)
            {
                sum += item.units.GetUnit<ActiveChannal>().GetValue();
            }
            return sum + bias;
        }
    }
}
