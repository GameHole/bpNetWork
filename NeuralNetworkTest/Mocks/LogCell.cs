using NeuralNetwork;
using System.Collections.Generic;

namespace NeuralNetworkTest
{
    class LogCell 
    {
        internal string log;

        public LogCell(Cell cell)
        {
            cell.units.GetUnit<ActiveCellUnit>().onActive += () =>
            {
                log += "active ";
            };
        }
    }
}
