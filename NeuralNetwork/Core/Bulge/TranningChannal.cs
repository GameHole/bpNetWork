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
                counting = value.units.GetUnit<CountingChannal>().counter;
                To = value.to.units.GetUnit<TranningChannal, TranningBasic>();
            }
        }
        public Counter counting;
        private TranningBasic To;

        public double deltaWeigth;
        public override void ActiveSelf()
        {
            deltaWeigth = getToDeltaBias() * bulge.from.value;
            counting.Count(deltaWeigth);
        }

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
