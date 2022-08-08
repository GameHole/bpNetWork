using System;
using System.Collections;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Bulge
    {
        public double weight;
        public BulgeUnitContainer units { get; }
        public Bulge()
        {
            units = new BulgeUnitContainer(this);
        }
    }
}
