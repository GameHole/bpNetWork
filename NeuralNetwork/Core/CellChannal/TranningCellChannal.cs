using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TranningCellChannal : ACellChannal
    {
        public ActiveCellChannal act;
        public CountingCellChannal countting;
        public double deltaBias { get;internal set; }
        

        protected override List<Bulge> toBulges => cell.inputs;

        protected override List<Bulge> fromBulges => cell.outputs;

        protected override void ActiveSelf()
        {
            deltaBias = integrate() * cell.actviter.Derivative(act.integrate());
            countting.tranCount++;
        }

        protected override AChannal getChannal(Bulge item)
        {
            return item.tranning;
        }
    }
}
