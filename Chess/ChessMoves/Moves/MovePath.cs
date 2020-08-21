using ChessMoves;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Moves
{
    class MovePath
    {
        public MovePath(Piece piece) => Piece = piece;

        public Piece Piece { get; }

        internal IPath GetPath(IUserMove move)
        {
            if (move is MoveUserMove)
                return Piece.Moves().Where(x => x.End == move.Index).Single();
            else if (move is CaptureUserMove)
                return Piece.Captures().Where(x => x.End == move.Index).Single();
            return null;
        }
    }
}
