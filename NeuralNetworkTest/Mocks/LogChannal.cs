using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class LogChannal : AChannal
    {
        internal string log;

        public override double GetValue()
        {
            throw new NotImplementedException();
        }

        public override void ActiveSelf()
        {
            log += "active";
        }

        public override void onDeactive()
        {
            log += "reset";
        }

    }
}
