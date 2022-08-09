using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CellUnit<T, A> : ACellUnit<T> where T : AChannal, new() where A:AUnitAction,new()
    {
        public bool _inverse;
        public override bool activeInverse => _inverse;
        public override Cell cell { get => action.cell; set => action.cell = value; }
        public A action { get; set; }
        public CellUnit():this(false)
        {
            
        }
        public CellUnit(bool isInverse)
        {
            _inverse = isInverse;
            action = new A();
        }

        public override void ActiveSelf()
        {
            action.ActiveSelf();
        }
    }
}
