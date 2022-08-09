using NeuralNetwork;
namespace NeuralNetworkTest
{
    internal class LogActiveUnit:ACellUnit<ActiveChannal>
    {
        internal string log;

        public override void ActiveSelf()
        {
            log += "active ";
        }
    }
}