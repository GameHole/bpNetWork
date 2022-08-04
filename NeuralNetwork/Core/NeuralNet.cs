using System.Collections.Generic;

namespace NeuralNetwork
{
    public class NeuralNet
    {
        public List<ValueCell> Input { get; set; } = new List<ValueCell>();
        public List<Cell> OutPut { get; set; } = new List<Cell>();
    }
}
