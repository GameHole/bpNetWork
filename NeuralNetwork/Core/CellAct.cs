using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    class CellAct : ACellChannal
    {
        public event Action onActive;

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
            return base.integrate() + cell.bias;
        }

        protected override AChannal getChannal(Bulge item)
        {
            return item.active;
        }
    }
}
