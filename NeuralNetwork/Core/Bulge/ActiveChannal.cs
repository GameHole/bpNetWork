namespace NeuralNetwork
{
    public class ActiveChannal: AChannal
    {
        protected override void ActiveCellAction(ACell cell)
        {
            (cell as IActivable)?.Active();
        }

        public override double GetValue()
        {
            return from.value * bulge. weight;
        }
    }
}
