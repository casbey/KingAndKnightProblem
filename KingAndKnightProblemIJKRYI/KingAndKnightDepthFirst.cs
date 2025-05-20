using KingAndKnightProblemIJKRYI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class KingAndKnightDepthFirst : BaseOfGraphSearchAlgorithms
    {
        private Stack<KingAndKnightNode> openNodes;
        private List<KingAndKnightNode> closedNodes;
        private bool circleCheck;

        public KingAndKnightDepthFirst(bool circleCheck = true)
        {
            this.circleCheck = circleCheck;
            openNodes = new Stack<KingAndKnightNode>();
            openNodes.Push(new KingAndKnightNode());
            if (circleCheck)
            {
                closedNodes = new List<KingAndKnightNode>();
            }
        }

        public override KingAndKnightNode FindTerminalNode()
        {
            if (circleCheck) return DepthFirst();
            return DepthFirstQuick();
        }

        public KingAndKnightNode DepthFirst()
        {
            while (openNodes.Count != 0)
            {
                KingAndKnightNode node = openNodes.Pop();
                List<KingAndKnightNode> children = node.Extend();
                foreach (KingAndKnightNode child in children)
                {
                    if (child.IsTerminalNode)
                    {
                        return child;
                    }

                    if (!closedNodes.Contains(child) && !openNodes.Contains(child))
                    {
                        openNodes.Push(child);
                    }
                }
                closedNodes.Add(node);
            }
            return null;
        }

        public KingAndKnightNode DepthFirstQuick()
        {
            while (openNodes.Count != 0)
            {
                KingAndKnightNode node = openNodes.Pop();
                List<KingAndKnightNode> children = node.Extend();
                foreach (KingAndKnightNode child in children)
                {
                    if (child.IsTerminalNode)
                    {
                        return child;
                    }
                    openNodes.Push(child);
                }
            }
            return null;
        }

    }
}
