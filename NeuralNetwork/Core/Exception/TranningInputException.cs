using System;

namespace NeuralNetwork
{

    [Serializable]
    public class TranningInputException : Exception
    {
        public TranningInputException() { }
        public TranningInputException(string message) : base(message) { }
        public TranningInputException(string message, Exception inner) : base(message, inner) { }
        protected TranningInputException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
