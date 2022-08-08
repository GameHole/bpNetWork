﻿using NeuralNetwork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class TestAChannal
    {
        LogChannal channal;
        [SetUp]
        public void SetUp()
        {
            channal = new LogChannal();
            var bulge = new Bulge();
            var cell = new Cell();
            cell.units.AddUnit<LogUnit>();
            bulge.from = cell;
            bulge.to = cell;
            channal.bulge = bulge;
        }
        [Test]
        public void TestActive()
        {
            Assert.IsFalse(channal.isActiveted);
            for (int i = 0; i < 2; i++)
            {
                channal.Active(null);
            }
            Assert.IsTrue(channal.isActiveted);
            Assert.AreEqual("active", channal.log);
        }
        [Test]
        public void TestReset()
        {
            channal.Active(null);
            for (int i = 0; i < 2; i++)
            {
                channal.Deactive();
            }
            Assert.IsFalse(channal.isActiveted);
            Assert.AreEqual("activereset", channal.log);
        }
    }
}
