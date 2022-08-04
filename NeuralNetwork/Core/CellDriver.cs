namespace NeuralNetwork
{
    public class CellDriver
    {
        public void Active(ACell cell)
        {
            (cell as IActivable)?.Active();
        }

    }
}
