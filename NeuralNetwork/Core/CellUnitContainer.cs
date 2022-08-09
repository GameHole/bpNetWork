using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CellUnitContainer : Container<CellUnitBase>
    {
        public T GetUnit<T>() where T:CellUnitBase
        {
            return GetUnit(getChannalType(typeof(T))) as T;
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

        public CellUnitBase GetUnit(Type channalType)
        {
            return Get(channalType);
        }

        public void AddUnit<T>(T item) where T :CellUnitBase
        {
            Add(item.ChannalType, item);
        }
    }
}
