using System;

namespace NeuralNetwork
{
    public class Actviter
    {
        public double Actvite(double integration)
        {
            return 1 / (1 + Math.Pow(Math.E, -integration));
        }

        public double Derivative(double integration)
        {
            var fu = Actvite(integration);
            return fu * (1 - fu);
        }
    }
}
