using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Container<T>:IEnumerable<T>
    {
        protected Dictionary<Type, T> units = new Dictionary<Type, T>();

        public int Count => units.Count;

        public T Get(Type type)
        {
            units.TryGetValue(type, out var unit);
            return unit;
        }
        public void Add(Type key,T value)
        {
            units.Add(key, value);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return units.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Clear()
        {
            units.Clear();
        }
        public void Set(Type type, T unit)
        {
            units[type] = unit;
        }
    }
}
