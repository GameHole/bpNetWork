using System;

namespace NeuralNetwork
{
    public interface IActivable
    {
        event Action onActive;
        void Active();
    }
}
