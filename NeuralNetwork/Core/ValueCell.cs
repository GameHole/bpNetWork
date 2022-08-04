using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class ValueCell : ACell,IActivable
    {

        public event Action onActive;

        public void Active() 
        {
            ActiveBulges(outputs);
            onActive?.Invoke();
        }
    }
}
