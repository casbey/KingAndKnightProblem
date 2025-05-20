using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public abstract class BaseOfGraphSearchAlgorithms
    {
        private KingAndKnightNode startNode;

        protected BaseOfGraphSearchAlgorithms()
        {
            startNode = new KingAndKnightNode();
        }

        protected KingAndKnightNode StartNode { get { return startNode; } }

        public abstract KingAndKnightNode FindTerminalNode();

        public Stack<KingAndKnightState> PathOfSolution(KingAndKnightNode terminalNode)
        {
            if (terminalNode == null)
            {
                throw new Exception("Something is wrong.");
            }

            Stack<KingAndKnightState> solution = new Stack<KingAndKnightState>();
            KingAndKnightNode actual = terminalNode;
            while (actual != null)
            {
                solution.Push(actual.State);
                actual = actual.Parent;
            }
            return solution;
        }
    }
}
