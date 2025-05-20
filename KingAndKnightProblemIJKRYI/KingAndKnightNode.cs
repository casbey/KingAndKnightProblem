using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class KingAndKnightNode
    {
        private KingAndKnightState state;
        private KingAndKnightNode parent;
        private int depth;

        public KingAndKnightNode()
        {
            this.state = new KingAndKnightState();
            this.depth = 0;
            this.parent = null;
        }

        public KingAndKnightNode(KingAndKnightNode parent)
        {
            this.state = (KingAndKnightState)parent.state.Clone();
            this.depth = parent.depth + 1;
            this.parent = parent;
        }

        public KingAndKnightNode Parent { get { return this.parent; } }
        public int Depth { get { return this.depth; } }
        public bool IsTerminalNode { get { return this.state.IsGoalState; } }
        public KingAndKnightState State { get { return (KingAndKnightState)this.state.Clone(); } }

        public override bool Equals(object? obj)
        {
            KingAndKnightNode other = (KingAndKnightNode)obj;
            return this.state.Equals(other.state);
        }

        public override string ToString()
        {
            return this.state.ToString();
        }

        public List<KingAndKnightNode> Extend()
        {
            List<KingAndKnightNode> newNodes = new List<KingAndKnightNode>();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    KingAndKnightNode newNode = new KingAndKnightNode(this);
                    if (newNode.state.ApplyMove(row, col))
                    {
                        newNodes.Add(newNode);
                    }
                }
            }

            return newNodes;
        }
    }
}
