using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class KingAndKnightBreadthFirst : BaseOfGraphSearchAlgorithms
    {
        private Queue<KingAndKnightNode> openNodes;
        private List<KingAndKnightNode> closedNodes;

        public KingAndKnightBreadthFirst()
        {
            openNodes = new Queue<KingAndKnightNode>();
            closedNodes = new List<KingAndKnightNode>();
            openNodes.Enqueue(StartNode);
        }

        public override KingAndKnightNode FindTerminalNode()
        {
            while (openNodes.Count > 0)
            {
                KingAndKnightNode current = openNodes.Dequeue();

                if (current.IsTerminalNode)
                {
                    return current;
                }

                closedNodes.Add(current);

                foreach (KingAndKnightNode child in current.Extend())
                {
                    if (!closedNodes.Contains(child) && !openNodes.Contains(child))
                    {
                        openNodes.Enqueue(child);
                    }
                }
            }

            return null;
        }
    }
}
