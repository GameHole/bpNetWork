namespace NeuralNetwork
{
    public class ActiveChannal: AChannal
    {
        public double GetValue()
        {
            return bulge.from.value * bulge.weight;
        }
    }
}
