using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class TranningCell:Cell
    {
        public TranningCell()
        {
            tranning = new NoneTranningChannal();
        }
        public override Bulge AddInput(Cell cell)
        {
            if (inputs.Count >= 1)
                throw new TranningInputException("TranningCell can only one input cell");
            return base.AddInput(cell);
        }

        public void Reset()
        {
            input.counting.Active(this);
        }

        public double ieta;
        private Bulge input => inputs[0];
        public void Tran()
        {
            input.Deactive();
            input.active.Active(this);
            input.weight = 1;
            tranning.deltaBias = ieta * (value - input.active.GetValue());
            input.tranning.Active(this);
        }

        public void Apply()
        {
            input.apply.Active(this);
        }
    }
}
