namespace NeuralNetwork
{
    public class TranningChannal: AChannal
    {
        public double deltaWeigth;

        protected override void ActiveSelf()
        {
            bulge.tranCount++;
            deltaWeigth = getToDeltaBias() * from.value;
        }

        protected override ACell fromCell => to;
        protected override ACell toCell => from;

        protected override void ActiveCellAction(ACell cell)
        {
            (cell as ITranable)?.Tran();
        }

        private double getToDeltaBias()
        {
            if (to is ITranable tranable)
                return tranable.deltaBias;
            return 0;
        }
        public override double GetValue()
        {
            return getToDeltaBias() * bulge.weight;
        }
    }
}
