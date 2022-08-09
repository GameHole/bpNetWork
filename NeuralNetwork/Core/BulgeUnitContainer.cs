using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class BulgeUnitContainer : Container<AChannal>
    {
        private Bulge bulge;
        public BulgeUnitContainer(Bulge bulge)
        {
            this.bulge = bulge;
        }
        public T AddUnit<T>() where T : AChannal, new()
        {
            //var item = GetUnit<T>();
            //if (item == null)
            //{
            //    item = new T();
            //    Add(typeof(T), item);
            //    item.bulge = bulge;
            //}
            //return item;
            return AddUnit(typeof(T)) as T;
        }
        public AChannal AddUnit(Type channalType)
        {
            var item = Get(channalType);
            if (item == null)
            {
                item = Activator.CreateInstance(channalType) as AChannal;
                Add(channalType, item);
                item.bulge = bulge;
            }
            return item;
        }
        public T GetUnit<T>() where T : AChannal
        {
            return Get(typeof(T)) as T;
        }
    }
}
