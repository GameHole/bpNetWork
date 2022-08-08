namespace NeuralNetwork
{
    public class CellDriver
    {
        public void Active(Cell cell)
        {
            cell.units.GetUnit<ActiveCellUnit>().Active();
        }

    }
}
