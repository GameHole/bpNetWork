using NeuralNetwork;
using System.Collections.Generic;

namespace NeuralNetworkTest
{
    class LogCell 
    {
        internal string log;

        public LogCell(ACell cell)
        {
            if(cell is IActivable activable)
            {
                activable.onActive += () =>
                {
                    log += "active ";
                };
            }
        }
    }
}
