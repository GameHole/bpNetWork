using NeuralNetwork;
using NUnit.Framework;

namespace NeuralNetworkTest
{
    public class TestBulge
    {
        [Test]
        public void testBulge()
        {
            var input = new ValueCell() { value = 1.5 };
            var cell = new Cell();
            var bulge = cell.AddInput(input);
            bulge.weight = 0.5;
            Assert.AreEqual(0.75, bulge.units.GetUnit<ActiveChannal>().GetValue());
            bulge.weight = 0.1;
            Assert.AreEqual(0.1, bulge.weight);
            Assert.AreEqual(0.15, bulge.units.GetUnit<ActiveChannal>().GetValue(),0.0001);
        }
       
        [Test]
        public void testInitBulge()
        {
            var bulge = new Bulge();
            Assert.GreaterOrEqual(bulge.weight,0);
            Assert.LessOrEqual(bulge.weight,1);
        }
        [Test]
        public void testResetBulge()
        {
            var cell = new Cell();
            var bulge = cell.AddInput(new Cell());
            foreach (var item in cell.units)
            {
                cell.Active(item);
            }
            cell.Deactive();
            foreach (var item in bulge.units)
            {
                Assert.IsFalse(item.isActiveted);
            }
        }
        [Test]
        public void testLinkUnit()
        {
            var cells = TestCellActive.MakeCells(2);
            var bulge = cells[0].AddInput(cells[1]);
            var log = bulge.units.GetUnit<LogChannal>();
            Assert.NotNull(log);
            Assert.AreSame(log.bulge, bulge);
        }
    }
}