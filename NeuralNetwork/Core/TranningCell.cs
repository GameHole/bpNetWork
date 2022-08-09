using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class TranningCell:Cell
    {
        private Bulge input;
        protected override void AddUnits()
        {
            units.AddUnit<ActiveChannal>();
            units.AddUnit<TranningChannal>(new TranningBasic());
            units.AddUnit<ApplyChannal>();
            units.AddUnit<CountingChannal>();
        }
        public override Bulge AddInput(Cell cell)
        {
            if (input != null)
                throw new TranningException("TranningCell can only one input cell");
            var item = base.AddInput(cell);
            input = item;
            return item;
        }

        public void Reset()
        {
            Active(typeof(CountingChannal));
        }

        public double ieta;

        public double difference { get;private set; }

        public void Tran()
        {
            Deactive();
            Active(typeof(ActiveChannal));
            input.weight = 1;
            difference = value - input.from.value;
            units.GetUnit<TranningChannal, TranningBasic>().deltaBias = ieta * difference;
            Active(typeof(TranningChannal));
        }

        public void Apply()
        {
            Active(typeof(ApplyChannal));
        }
    }
}
