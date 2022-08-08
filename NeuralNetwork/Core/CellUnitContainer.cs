using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CellUnitContainer : Container<ICellUnit>
    {
        private Cell cell;
        public CellUnitContainer(Cell cell)
        {
            this.cell = cell;
        }
        public T GetUnit<T>() where T:class,ICellUnit
        {
            return GetUnit(getChannalType(typeof(T))) as T;
        }

        private Type getChannalType(Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                    return type.GenericTypeArguments[0];
                type = type.BaseType;
            }
            return type;
        }

        public ICellUnit GetUnit(Type channalType)
        {
            return Get(channalType);
        }

        public T AddUnit<T>() where T :class,ICellUnit, new()
        {
            var item = GetUnit<T>();
            if (item == null)
            {
                item = new T();
                item.cell = cell;
                Add(item.ChannalType, item);
            }
            return item;
        }
    }
}
