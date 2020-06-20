using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ChessMoves
{
    internal class Queen : Piece
    {
        public Queen((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { base.PieceType = PieceType.Queen; }

        public Queen(string chessBoardIndex, Player playerColour) : 
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.Queen;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;

        }

        public override IEnumerable<IEnumerable<(int, int)>> GetLegalMoves()
        {
            var horizontalAndVertical = new Rock(base.CurrentPosition, Player.White).GetLegalMoves();
            var diagonals = new Bishop(base.CurrentPosition, Player.White).GetLegalMoves();

            return horizontalAndVertical.Concat(diagonals);
        }
    }
}