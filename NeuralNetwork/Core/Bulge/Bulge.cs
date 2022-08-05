using System;

namespace NeuralNetwork
{
    public class Bulge
    {
        public double weight;
        private ACell from;
        private ACell to;
        public int tranCount;

        public TranningChannal tranning { get; }
        public ActiveChannal active { get; }
        public AChannal apply { get; }

        public Bulge(ACell from, ACell to) :this(from,to, 0)
        {
        }
        public Bulge(ACell from,ACell to,double weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
            tranning = new TranningChannal();
            active = new ActiveChannal();
            apply = new ApplyChannal();
            tranning.Init(this, from, to);
            active.Init(this, from, to);
            apply.Init(this, from, to);
        }

        public void Reset()
        {
            active.Reset();
            tranning.Reset();
            apply.Reset();
        }
    }
}
