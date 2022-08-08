namespace NeuralNetwork
{
    public class ActiveChannal: AChannal
    {

        public override double GetValue()
        {
            return bulge.from.value * bulge.weight;
        }
    }
}
