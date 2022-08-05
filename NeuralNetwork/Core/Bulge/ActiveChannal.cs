namespace NeuralNetwork
{
    public class ActiveChannal: AChannal
    {
        protected override ACellChannal getCellChannal(Cell cell) => cell.active;
        public override double GetValue()
        {
            return from.value * bulge. weight;
        }
    }
}
