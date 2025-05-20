using KingAndKnightProblemIJKRYI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class KingAndKnightBackTrack : BaseOfGraphSearchAlgorithms
    {
        private int maxDepth;
        private bool circleCheck;

        public KingAndKnightBackTrack(int maxDepth = 0, bool circleCheck = true)
        {
            this.maxDepth = maxDepth;
            this.circleCheck = circleCheck;
        }

        public override KingAndKnightNode FindTerminalNode()
        {
            return FindTerminalNode(new KingAndKnightNode());
        }
        public KingAndKnightNode FindTerminalNode(KingAndKnightNode node)
        {
            if (maxDepth != 0 && node.Depth > maxDepth)
            {
                return null;
            }
            if (circleCheck)
            {
                KingAndKnightNode parent = node.Parent;
                while (parent != null)
                {
                    if (node.Equals(parent))
                    {
                        return null;
                    }
                    parent = parent.Parent;
                }
            }

            if (node.IsTerminalNode)
            {
                return node;
            }

            List<KingAndKnightNode> children = node.Extend();
            foreach (KingAndKnightNode child in children)
            {
                KingAndKnightNode terminalNode = FindTerminalNode(child);
                if (terminalNode != null)
                {
                    return terminalNode;
                }
            }
            return null;
        }
    }
}
