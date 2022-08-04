namespace NeuralNetwork
{
    public class Bulge
    {
        public double weight;
        internal ACell from { get; }
        internal ACell to { get; }
        public TranningChannal tranning { get; }
        public ActiveChannal active { get; }
        public Bulge(ACell from, ACell to) :this(from,to, 0)
        {
        }
        public Bulge(ACell from,ACell to,double weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
            tranning = new TranningChannal() { bulge = this };
            active = new ActiveChannal() { bulge = this };
        }
        public double GetValue()
        {
            return from.value * weight;
        }
    }
}
