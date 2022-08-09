using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetwork;
namespace NeuralNetworkTest
{
    class LogUnitAction : AUnitAction
    {
        internal string log;

        public override void ActiveSelf()
        {
            log += "active ";
        }
    }
}
