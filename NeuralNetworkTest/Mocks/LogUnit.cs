using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class LogUnit : ACellUnit<LogChannal>
    {
        internal bool isActive;

        public override void ActiveSelf()
        {
            isActive = true;
        }
    }
}
