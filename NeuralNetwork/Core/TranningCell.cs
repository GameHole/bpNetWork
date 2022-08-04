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
        public void Tran()
        {
            ActiveBulges(inputs);
            var input = inputs[0];
            input.weight = 1;
            deltaBias = ieta * (value - input.GetValue());
            TranBulges(inputs);
        }
    }
}
