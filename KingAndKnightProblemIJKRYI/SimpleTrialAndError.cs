using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class SimpleTrialAndError : BaseOfGraphSearchAlgorithms
    {
        private static Random rnd = new Random();
        public override KingAndKnightNode FindTerminalNode()
        {
            KingAndKnightNode actual = StartNode;
            while (!actual.IsTerminalNode)
            {
                List<KingAndKnightNode> nextLevelNodes = actual.Extend();
                actual = nextLevelNodes[rnd.Next(nextLevelNodes.Count)];
            }
            return actual;
        }
    }
}
