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

        protected override void ActiveCellAction(ACell cell)
        {
            
        }
        protected override void ActiveSelf()
        {
            log += "active";
        }
        protected override void onReset()
        {
            log += "reset";
        }

    }
}
