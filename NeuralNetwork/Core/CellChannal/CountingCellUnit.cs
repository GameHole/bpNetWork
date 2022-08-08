﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class CountingCellUnit : ACellUnit<CountingChannal>
    {
        public int tranCount;
        public double totalWidth;

        protected override void ActiveSelf()
        {
            tranCount = 0;
            totalWidth = 0;
        }

        public double GetValue()
        {
            return totalWidth / tranCount;
        }
    }
}
