using NeuralNetwork;
using System.Collections.Generic;

namespace NeuralNetworkTest
{
    class LogCell 
    {
        internal bool isActive;

        public LogCell(ACell cell)
        {
            if(cell is IActivable activable)
            {
                activable.onActive += () =>
                {
                    isActive = true;
                };
            }
        }
    }
}
