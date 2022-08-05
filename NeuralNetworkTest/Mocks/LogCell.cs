using NeuralNetwork;
using System.Collections.Generic;

namespace NeuralNetworkTest
{
    class LogCell 
    {
        internal string log;

        public LogCell(Cell cell)
        {
            cell.active.onActive += () =>
            {
                log += "active ";
            };
        }
    }
}
