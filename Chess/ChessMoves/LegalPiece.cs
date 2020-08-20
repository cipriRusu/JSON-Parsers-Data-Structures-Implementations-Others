using ChessMoves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class LegalPiece
    {
        private readonly IEnumerable<IPiece> AllPieces;
        public LegalPiece(IEnumerable<IPiece> allPieces) => AllPieces = allPieces;
        public IPiece GetMovablePiece(IUserMove move, out IPath path)
        {
            var piece = AllPieces
                .Where(x => x != null)
                .Where(x => x.PlayerColour == move.PlayerColor)
                .Where(x => x.GetType() == move.PieceType)
                .Where(x => x.CanPerform(move));

            var legalPath = piece.Single().GetPath(move);

            path = legalPath;
            return piece.Single();
        }
    }
}
