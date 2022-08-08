﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetwork;
namespace NeuralNetworkTest
{
    class TestCounting
    {
        [Test]
        public void testCounter()
        {
            var counting = new Counter();
            for (int i = 0; i < 10; i++)
            {
                counting.Count(i+1);
            }
            Assert.AreEqual(5.5, counting.GetValue());
            counting.Reset();
            Assert.AreEqual(0, counting.tranCount);
            Assert.AreEqual(0, counting.totalWidth);
        }
        [Test]
        public void testCounterCount()
        {
            var counting = new Counter();
            counting.Count(0.1);
            Assert.AreEqual(0.1, counting.totalWidth);
            Assert.AreEqual(1, counting.tranCount);
        }
        [Test]
        public void testUnit()
        {
            var counting = new CountingCellUnit();
            counting.totalWidth = 5;
            counting.tranCount = 10;
            Assert.AreEqual(0.5, counting.GetValue());
            counting.Active();
            Assert.AreEqual(0, counting.tranCount);
            Assert.AreEqual(0, counting.totalWidth);
        }
        [Test]
        public void testChannal()
        {
            var counting = new CountingChannal();
            for (int i = 0; i < 10; i++)
            {
                counting.Count(0.5);
            }
            Assert.AreEqual(0.5, counting.GetValue());
            counting.Active(null);
            Assert.AreEqual(0, counting.tranCount);
        }
    }
}