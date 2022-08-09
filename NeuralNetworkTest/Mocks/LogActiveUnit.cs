using NeuralNetwork;
namespace NeuralNetworkTest
{
    internal class LogActiveUnit:AUnitAction
    {
        internal string log;

        public override void ActiveSelf()
        {
            log += "active ";
        }
    }
}