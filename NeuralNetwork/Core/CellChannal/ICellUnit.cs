using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public interface ICellUnit
    {
        public Type ChannalType { get; }
        public Cell cell { get; set; }
        void AddFrom(ICellUnit from, Bulge bulge);
        void Deactive();
        void Active();
    }
}
