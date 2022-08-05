namespace NeuralNetwork
{
    public class TranningChannal: AChannal
    {
        public CountingChannal counting;
        public double deltaWeigth;

        protected override void ActiveSelf()
        {
            counting.tranCount++;
            deltaWeigth = getToDeltaBias() * from.value;
        }

        protected override Cell fromCell => to;
        protected override Cell toCell => from;

        protected override ACellChannal getCellChannal(Cell cell) => cell.tranning;
        private double getToDeltaBias()
        {
            return to.tranning.deltaBias;
        }
        public override double GetValue()
        {
            return getToDeltaBias() * bulge.weight;
        }
    }
}
