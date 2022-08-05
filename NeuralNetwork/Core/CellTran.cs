using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    class CellTran : ACellChannal
    {

        public CellAct act;
        public double deltaBias { get; private set; }


        protected override List<Bulge> toBulges => cell.inputs;

        protected override List<Bulge> fromBulges => cell.outputs;

        protected override void ActiveSelf()
        {
            deltaBias = integrate() * cell.actviter.Derivative(act.integrate());
        }

        protected override AChannal getChannal(Bulge item)
        {
            return item.tranning;
        }
    }
}
