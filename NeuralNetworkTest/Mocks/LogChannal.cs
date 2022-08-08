using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class LogChannal : AChannal
    {
        internal string log;


        public override void ActiveSelf()
        {
            log += "active";
        }

    }
}
