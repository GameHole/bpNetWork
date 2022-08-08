namespace NeuralNetwork
{
    public class CellDriver
    {
        public void Active(Cell cell)
        {
            cell.Active(cell.units.GetUnit<ActiveCellUnit>());
        }

    }
}
