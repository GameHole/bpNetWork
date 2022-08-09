namespace NeuralNetwork
{
    public class TranningChannal: AChannal
    {
        public override Bulge bulge
        {
            get => base.bulge;
            set
            {
                base.bulge = value;
                counting = value.units.AddUnit<CountingChannal>();
            }
        }
        public CountingChannal counting;
        public double deltaWeigth;
        private TranningBasic To => bulge.to.units.GetUnit<CellUnit<TranningChannal, TranningBasic>>().action;
        public override void ActiveSelf()
        {
            deltaWeigth = getToDeltaBias() * bulge.from.value;
            counting.counter.Count(deltaWeigth);
        }

        internal override bool activeInverse => true;


        private double getToDeltaBias()
        {
            return To.deltaBias;
        }
        public double GetValue()
        {
            return getToDeltaBias() * bulge.weight;
        }
    }
}
