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
            int hKnight = KnightDistance(node.State.KnightRow, node.State.KnightCol, 0, 6);
            int hKing = Math.Max(Math.Abs(node.State.KingRow - 0), Math.Abs(node.State.KingCol - 6));

            return Math.Min(hKnight, hKing);
        }

        private int KnightDistance(int r1, int c1, int r2, int c2)
        {
            int dr = Math.Abs(r1 - r2);
            int dc = Math.Abs(c1 - c2);
            int max = Math.Max(dr, dc);
            int min = Math.Min(dr, dc);

            if (dr == 1 && dc == 0 || dr == 0 && dc == 1) return 3;
            if (dr == 1 && dc == 1) return 4;
            if (dr == 0 && dc == 0) return 0;
            if (dr + dc == 3 && (dr == 1 || dc == 1)) return 1;
            return (max + 1) / 2;
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
