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
        private TranningCellUnit To => to as TranningCellUnit;
        protected override void ActiveSelf()
        {
            deltaWeigth = getToDeltaBias() * from.cell.value;
            counting.Count(deltaWeigth);
        }

        protected override bool activeInverse => true;


        private double getToDeltaBias()
        {
            return To.deltaBias;
        }
        public override double GetValue()
        {
            return getToDeltaBias() * bulge.weight;
        }
    }
}
