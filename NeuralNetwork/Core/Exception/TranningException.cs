using System;

namespace NeuralNetwork
{

    [Serializable]
    public class TranningException : Exception
    {
        public TranningException() { }
        public TranningException(string message) : base(message) { }
        public TranningException(string message, Exception inner) : base(message, inner) { }
        protected TranningException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
