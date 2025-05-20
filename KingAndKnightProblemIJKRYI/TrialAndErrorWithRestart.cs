using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class TrialAndErrorWithRestart : BaseOfGraphSearchAlgorithms
    {
        private int maxLenghtOfSolution;
        private int nrOfRounds;
        private static Random rnd = new Random();

        public TrialAndErrorWithRestart(int maxLenghtOfSolution, int nrOfRounds)
        {
            this.maxLenghtOfSolution = maxLenghtOfSolution;
            this.nrOfRounds = nrOfRounds;
        }

        public override KingAndKnightNode FindTerminalNode()
        {
            KingAndKnightNode bestNode = null;
            int bestDepth = int.MaxValue;

            for (int round = 0; round < nrOfRounds; round++)
            {
                KingAndKnightNode current = new KingAndKnightNode();

                while (!current.IsTerminalNode && current.Depth < maxLenghtOfSolution)
                {
                    List<KingAndKnightNode> children = current.Extend();
                    if (children.Count == 0)
                        break;

                    current = children[rnd.Next(children.Count)];
                }

                if (current.IsTerminalNode && current.Depth < bestDepth)
                {
                    bestNode = current;
                    bestDepth = current.Depth;
                }
            }

            return bestNode;
        }
    }
}
