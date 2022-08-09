using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class LogUnit : AUnitAction
    {
        internal bool isActive;

        public override void ActiveSelf()
        {
            isActive = true;
        }
    }
}
