using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class TranningCell:ACell, ITranable
    {
        public Bulge AddInput(Cell cell)
        {
            if (inputs.Count >= 1)
                throw new TranningInputException("TranningCell can only one input cell");
            return base.AddInput(cell);
        }
        public double ieta;

        public double deltaBias { get; private set; }

        private Bulge input => inputs[0];
        public void Tran()
        {
            input.Reset();
            input.active.Active(this);
            input.weight = 1;
            deltaBias = ieta * (value - input.active.GetValue());
            input.tranning.Active(this);
        }

        public void Apply()
        {
            input.apply.Active(this);
        }
    }
}
