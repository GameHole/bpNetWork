using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CellUnitContainer : Container<CellUnit>
    {
        public T GetUnit<C, T>() where C : AChannal where T : AUnitAction
        {
            return GetUnit(typeof(C)).Action as T;
        }

        public Type getChannalType(Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                    return type.GenericTypeArguments[0];
                type = type.BaseType;
            }
            return type;
        }

        public CellUnit GetUnit(Type channalType)
        {
            return Get(channalType);
        }

        public void AddUnit(CellUnit item)
        {
            Add(item.ChannalType, item);
        }
        public void AddUnit<T>(AUnitAction item, bool inverseDirection = false)
        {
            AddUnit(new CellUnit(typeof(T), item, inverseDirection));
        }
        public void AddUnit<T>()
        {
            AddUnit(new CellUnit(typeof(T)));
        }
    }
}
