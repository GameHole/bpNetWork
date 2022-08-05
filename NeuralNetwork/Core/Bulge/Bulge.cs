using System;

namespace NeuralNetwork
{
    public class Bulge
    {
        public double weight;
        private Cell from;
        private Cell to;
       

        public TranningChannal tranning { get; }
        public ActiveChannal active { get; }
        public CountingChannal counting { get; }
        public AChannal apply { get; }

        public Bulge(Cell from, Cell to) :this(from,to, 0)
        {
        }
        public Bulge(Cell from,Cell to,double weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
            counting = new CountingChannal();
            tranning = new TranningChannal() { counting = counting };
            active = new ActiveChannal();

            apply = new ApplyChannal();
            
            tranning.Init(this, from, to);
            active.Init(this, from, to);
            apply.Init(this, from, to);
            counting.Init(this, from, to);
        }

        public void Deactive()
        {
            active.Deactive();
            tranning.Deactive();
            apply.Deactive();
        }
    }
}
