using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class PawnAggregate
    {
        private Piece[,] pieceBoard;
        private Player player;

        public IEnumerable<(int, int)> Attacks => GetAttackPoints(player);
        public PawnAggregate(Piece[,] pieceBoard, Player player)
        {
            this.pieceBoard = pieceBoard;
            this.player = player;
        }

        private IEnumerable<(int, int)> GetAttackPoints(Player player)
        {
            var attacks = Enumerable.Empty<IEnumerable<(int, int)>>();

            for(int i = 0; i <= 7; i++)
            {
                for(int j = 0; j <= 7; j++)
                {
                    if(pieceBoard[i, j] != null && 
                       pieceBoard[i, j].PlayerColour == player && 
                       pieceBoard[i, j].PieceType == PieceType.Pawn)
                    {
                        attacks = attacks.Concat(pieceBoard[i, j].PawnCapture());
                    }
                }
            }

            return attacks.SelectMany(x => x);
        }
    }
}
