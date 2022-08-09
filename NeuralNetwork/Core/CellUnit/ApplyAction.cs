using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ApplyAction:AUnitAction
    {

        public Counter counting;

        public ActiveAction active;
        public override void ActiveSelf()
        {
            active.bias += counting.GetValue();
        }
    }
}
