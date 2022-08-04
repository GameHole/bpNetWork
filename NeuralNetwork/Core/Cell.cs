using System;

namespace NeuralNetwork
{
    public class Cell:ACell,IActivable, ITranable
    {
        public double bias;
        private Actviter actviter = new Actviter();

        public Bulge AddInput(Cell cell)
        {
            return base.AddInput(cell);
        }
        public Bulge AddInput(ValueCell cell)
        {
            return base.AddInput(cell);
        }
        public event Action onActive;


        public void Active()
        {
            ActiveBulges(inputs);
            ActiveSelf();
            ActiveBulges(outputs);
            onActive?.Invoke();
        }

        private void ActiveSelf()
        {
            value = actviter.Actvite(integrate());
        }
        public double integrate()
        {
            double sum = 0;
            foreach (var item in inputs)
            {
                sum += item.GetValue();
            }
            return sum + bias;
        }

        public double deltaBias { get; private set; }
        public void Tran()
        {
            TranBulges(outputs);
            deltaBias = integrateDeltaBias() * actviter.Derivative(integrate());
            TranBulges(inputs);
        }
        private double integrateDeltaBias()
        {
            double sum = 0;
            foreach (var item in outputs)
            {
                sum += item.tranning.GetDeltaBias();
            }
            return sum;
        }
    }
}
