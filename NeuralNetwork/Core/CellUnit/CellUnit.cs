using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CellUnit
    {
        public Type ChannalType;
        public bool activeInverse;

        public AUnitAction Action;

        public CellUnit(Type ChannalType, AUnitAction Action, bool activeInverse = false)
        {
            this.ChannalType = ChannalType;
            this.activeInverse = activeInverse;
            this.Action = Action;
        }
        public CellUnit(Type ChannalType,bool activeInverse = false)
        {
            this.ChannalType = ChannalType;
            this.activeInverse = activeInverse;
            this.Action = new NoneUnitAction();
        }
    }
}
