using System;

namespace NeuralNetwork
{
    public class Cell:ACell,IActivable, ITranable,IApplyable
    {
        public double bias;
        internal Actviter actviter = new Actviter();
        public Cell()
        {
            act = new CellAct() { cell = this };
            tran = new CellTran() { cell = this, act = act };
            apply = new CellApply() { cell = this };
        }

        public Bulge AddInput(Cell cell)
        {
            return base.AddInput(cell);
        }
        public Bulge AddInput(ValueCell cell)
        {
            return base.AddInput(cell);
        }
        private CellAct act;
        private CellTran tran;
        private CellApply apply;
        public int tranCount { get; private set; }

        public event Action onActive { add => act.onActive += value; remove => act.onActive -= value; }


        public void Active()
        {
            act.Active();
        }
        public void Apply()
        {
            apply.Active();
        }

        public double deltaBias => tran.deltaBias;

        public void Tran()
        {
            tranCount++;
            tran.Active();
        }
    }
}
