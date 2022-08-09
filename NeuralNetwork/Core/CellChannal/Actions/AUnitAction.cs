namespace NeuralNetwork
{
    public abstract class AUnitAction
    {
        public virtual Cell cell { get; set; }
        public abstract void ActiveSelf();
    }
}