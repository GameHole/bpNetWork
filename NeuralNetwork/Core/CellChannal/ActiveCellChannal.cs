using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class ActiveCellChannal : ACellChannal
    {
        public event Action onActive;
        public double bias;
        public override void Active()
        {
            base.Active();
            onActive?.Invoke();
        }
        protected override void ActiveSelf()
        {
            cell.value = cell.actviter.Actvite(integrate());
        }
        public override double integrate()
        {
            return base.integrate() + bias;
        }

        protected override AChannal getChannal(Bulge item)
        {
            return item.active;
        }
    }
}
