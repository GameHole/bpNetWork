using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NeuralNetwork;
namespace NeuralNetworkTest
{
    class TestTraner
    {
        Traner traner;
        [SetUp]
        public void SetUp()
        {
            traner = new Traner();
        }
        [Test]
        public void testSample()
        {
            var sample = new Sample();
            Assert.AreEqual(0,sample.inputs.Count);
            Assert.AreEqual(0,sample.outputs.Count);
        }
        [Test]
        public void testTraner()
        {
            Assert.AreEqual(0, traner.inputs.Count);
            Assert.AreEqual(0, traner.outputs.Count);
        }
        [Test]
        public void testAddSample()
        {
            var sample = new Sample();
            for (int i = 0; i < 2; i++)
            {
                sample.inputs.Add(1);
            }
            sample.outputs.Add(0.5);
            var cell = new Cell();
            traner.outputs.Add(cell);
            for (int i = 0; i < 2; i++)
            {
                var input = new ValueCell() { value = 1.5 };
                cell.AddInput(input);
                traner.inputs.Add(input);
            }
            traner.AddSample(sample);
        }
        [Test]
        public void testAddSampleException()
        {
            var sample = new Sample();
            var ex = Assert.Throws<TranningException>(() =>
            {
                traner.AddSample(sample);
            });
            Assert.AreEqual($"Input or output do not match for tranner", ex.Message);
        }
    }
}
