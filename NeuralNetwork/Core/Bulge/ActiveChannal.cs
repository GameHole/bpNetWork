namespace NeuralNetwork
{
    public class ActiveChannal: AChannal
    {

        public override double GetValue()
        {
            System.Console.WriteLine($"ActiveChannal:from {from.cell},to {to.cell},{from.cell.value},{to.cell.value}");
            return from.cell.value * bulge.weight;
        }
    }
}
