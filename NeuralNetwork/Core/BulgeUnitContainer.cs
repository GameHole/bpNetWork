using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class BulgeUnitContainer : Container<AChannal>
    {
        public T AddUnit<T>() where T : AChannal, new()
        {
            return AddUnit(typeof(T),false) as T;
        }
        public AChannal AddUnit(Type channalType,bool activeInverse)
        {
            var item = Activator.CreateInstance(channalType) as AChannal;
            item.activeInverse = activeInverse;
            Add(channalType, item);
            return item;
        }
        public T GetUnit<T>() where T : AChannal
        {
            return Get(typeof(T)) as T;
        }
    }
}
