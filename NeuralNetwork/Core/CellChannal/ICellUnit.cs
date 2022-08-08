using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public interface ICellUnit
    {
        public Type ChannalType { get; }
        public Cell cell { get; set; }
        bool activeInverse { get; }

        void AddChannal(Bulge bulge);
        void ActiveSelf();
    }
}
