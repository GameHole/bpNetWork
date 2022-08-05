using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ApplyChannal : AChannal
    {
        public override double GetValue()
        {
            throw new NotImplementedException();
        }
        protected override void ActiveSelf()
        {
            bulge.weight += bulge.tranning.deltaWeigth;
        }
        protected override void ActiveCellAction(ACell cell)
        {
            (cell as IApplyable)?.Apply();
        }
    }
}
