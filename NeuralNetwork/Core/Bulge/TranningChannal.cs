namespace NeuralNetwork
{
    public class TranningChannal: AChannal
    {
        public double deltaWeigth;
        protected override void AccessInternal(ACell cell)
        {
            NotifyTo(cell);
            deltaWeigth = getToDeltaBata() * bulge.from.value;
            NotifyFrom(cell);
        }

        protected override void NotifyAction(ACell cell)
        {
            (cell as ITranable)?.Tran();
        }

        private double getToDeltaBata()
        {
            if (bulge.to is ITranable tranable)
                return tranable.deltaBias;
            return 0;
        }
        public double GetDeltaBias()
        {
            return getToDeltaBata() * bulge.weight;
        }
    }
}
