using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CellUnit<T, A> : CellUnitBase where T : AChannal, new() where A:AUnitAction,new()
    {
        public A action { get; set; }
        public CellUnit(A action) :this(action,false)
        {
            
        }
        public CellUnit(A action,bool isInverse)
        {
            ChannalType= typeof(T); 
            activeInverse = isInverse;
            this.action = action;
            Action = this.action;
        }
    }
}
