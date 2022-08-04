using NeuralNetwork;
using NUnit.Framework;

namespace NeuralNetworkTest
{
    public class TestBulge
    {
        [Test]
        public void testBulge()
        {
            var cell = new ValueCell();
            cell.value = 1.5;
            var bulge = new Bulge(cell, new ValueCell(), 0.5);
            Assert.AreEqual(0.75, bulge.GetValue());
            bulge.weight = 0.1;
            Assert.AreEqual(0.1, bulge.weight);
            Assert.AreEqual(0.15, bulge.GetValue(),0.0001);
        }
        [Test]
        public void testInitBulge()
        {
            var bulge = new Bulge(new ValueCell(), new ValueCell());
            Assert.GreaterOrEqual(bulge.weight,0);
            Assert.LessOrEqual(bulge.weight,1);
        }
    }
}