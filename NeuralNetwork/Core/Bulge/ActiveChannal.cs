namespace NeuralNetwork
{
    public class ActiveChannal: AChannal
    {
        protected override void NotifyAction(ACell cell)
        {
            (cell as IActivable)?.Active();
        }

        protected override void AccessInternal(ACell cell)
        {
            NotifyFrom(cell);
            NotifyTo(cell);
        }
    }
}
