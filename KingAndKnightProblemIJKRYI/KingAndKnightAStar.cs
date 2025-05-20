using KingAndKnightProblemIJKRYI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class KingAndKnightAStar : BaseOfGraphSearchAlgorithms
    {
        private List<KingAndKnightNode> closedNodes;
        private PriorityQueue<KingAndKnightNode, int> openNodes;

        public KingAndKnightAStar()
        {
            closedNodes = new List<KingAndKnightNode>();
            openNodes = new PriorityQueue<KingAndKnightNode, int>();
            openNodes.Enqueue(StartNode, Heuristic(StartNode));
        }

        private int Heuristic(KingAndKnightNode node)
        {
            int knightH = Math.Abs(node.State.KnightRow - 0) + Math.Abs(node.State.KnightCol - 6);
            int kingH = Math.Abs(node.State.KingRow - 0) + Math.Abs(node.State.KingCol - 6);

            return Math.Min(knightH, kingH);
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
                    if (closedNodes.Contains(child))
                    {
                        continue;
                    }

                    int f = child.Depth + Heuristic(child);

                    bool shouldEnqueue = true;
                    foreach (var item in openNodes.UnorderedItems)
                    {
                        if (item.Element.Equals(child) && item.Priority <= f)
                        {
                            shouldEnqueue = false;
                            break;
                        }
                    }

                    if (shouldEnqueue)
                    {
                        openNodes.Enqueue(child, f);
                    }
                }
            }
            return null;
        }
    }
}
