using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingAndKnightProblemIJKRYI
{
    public class KingAndKnightState : ICloneable
    {
        public KingAndKnightState()
        {
            this.kingRow = 2;
            this.kingCol = 1;
            this.knightRow = 2;
            this.knightCol = 2;
            this.isKnightTurn = true;
        }

        private int kingRow;
        private int kingCol;
        private int knightRow;
        private int knightCol;
        private bool isKnightTurn;

        public int KingRow { get { return kingRow; } }
        public int KingCol { get { return kingCol; } }
        public int KnightRow { get { return knightRow; } }
        public int KnightCol { get { return knightCol; } }
        public bool IsKnightTurn { get { return isKnightTurn; } }

        public bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }
        public bool IsState
        {
            get
            {
                bool piecesAreValid = IsInBounds(kingRow, kingCol) &&
                                      IsInBounds(knightRow, knightCol) &&
                                      (kingRow != knightRow || kingCol != knightCol);

                bool knightUnderAttack = IsKingAttackingKnight;
                bool kingUnderAttack = IsKnightAttackingKing;

                bool attackValidation = (isKnightTurn && knightUnderAttack) || (!isKnightTurn && kingUnderAttack);

                return piecesAreValid && attackValidation;
            }
        }

        public bool IsGoalState
        {
            get
            {
                return (kingRow == 0 && kingCol == 6) || (knightRow == 0 && knightCol == 6);
            }
        }

        private bool IsKnightAttackingKing
        {
            get
            {
                int dr = Math.Abs(knightRow - kingRow);
                int dc = Math.Abs(knightCol - kingCol);
                return (dr == 2 && dc == 1) || (dr == 1 && dc == 2);
            }
        }

        private bool IsKingAttackingKnight
        {
            get
            {
                return Math.Abs(kingRow - knightRow) <= 1 &&
                       Math.Abs(kingCol - knightCol) <= 1;
            }
        }

        public bool IsMove(int targetRow, int targetCol)
        {
            if (!IsInBounds(targetRow, targetCol)) return false;


            if (isKnightTurn)
            {
                if (targetRow == knightRow && targetCol == knightCol) return false;

                // L-shape, so +-2, +-1 or +-1, +-2
                int dr = Math.Abs(targetRow - knightRow);
                int dc = Math.Abs(targetCol - knightCol);
                bool isLegalKnightMove = (dr == 2 && dc == 1) || (dr == 1 && dc == 2);
                if (!isLegalKnightMove) return false;
                if (!IsKingAttackingKnight) return false;

            }
            else // King moves
            {
                if (targetRow == kingRow && targetCol == kingCol) return false;

                int dr = Math.Abs(targetRow - kingRow);
                int dc = Math.Abs(targetCol - kingCol);

                if (dr == 0 && dc == 0) return false;
                if (dr > 1 || dc > 1) return false;
                if (!IsKnightAttackingKing) return false;
            }

            return true;
        }

        public bool ApplyMove(int targetRow, int targetCol)
        {
            KingAndKnightState clone = (KingAndKnightState)this.Clone();

            if (!IsMove(targetRow, targetCol))
            {
                return false;
            }

            if (isKnightTurn)
            {
                this.knightRow = targetRow;
                this.knightCol = targetCol;
                this.isKnightTurn = IsKnightAttackingKing ? false : true;
            }
            else
            {
                this.kingRow = targetRow;
                this.kingCol = targetCol;
                this.isKnightTurn = IsKingAttackingKnight ? true : false;
            }

            if (IsState) return true;

            this.kingRow = clone.kingRow;
            this.kingCol = clone.kingCol;
            this.knightRow = clone.knightRow;
            this.knightCol = clone.knightCol;
            this.isKnightTurn = clone.isKnightTurn;
            return false;
        }

        public override string ToString()
        {
            string piece = isKnightTurn ? "Knight" : "King";
            return $"King: ({kingRow},{kingCol}), Knight: ({knightRow},{knightCol}), Turn: {piece}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj == this) return true;
            if (this.GetType() != obj.GetType()) return false;
            KingAndKnightState other = (KingAndKnightState)obj;
            return this.kingRow == other.kingRow &&
                   this.kingCol == other.kingCol &&
                   this.knightRow == other.knightRow &&
                   this.knightCol == other.knightCol &&
                   isKnightTurn == other.isKnightTurn;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
