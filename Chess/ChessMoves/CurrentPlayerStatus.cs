using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class CurrentPlayerStatus
    {
        private readonly Player turnToMove;
        private readonly ChessBoard chessBoard;

        public CurrentPlayerStatus(Player turnToMove, ChessBoard chessBoard)
        {
            this.turnToMove = turnToMove;
            this.chessBoard = chessBoard;
        }

        private bool KingCheckStatus()
        {
            Piece currentKing = FindKing();

            var diagonalAttacks = new Path(currentKing.CurrentPosition,
                new PathType[]
                {
                    PathType.Diagonals,
                })
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                chessBoard[x.Last()] != null &&
                chessBoard[x.Last()].PlayerColour == Piece.Opponent(turnToMove) &&
                (chessBoard[x.Last()].PieceType == PieceType.Queen ||
                chessBoard[x.Last()].PieceType == PieceType.Bishop)); ;

            var verticalHorizontalAttacks = new Path(currentKing.CurrentPosition,
                new PathType[]
                {
                    PathType.RowsAndColumns
                })
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                chessBoard[x.Last()] != null &&
                chessBoard[x.Last()].PlayerColour == Piece.Opponent(turnToMove) &&
                (chessBoard[x.Last()].PieceType == PieceType.Queen ||
                chessBoard[x.Last()].PieceType == PieceType.Rock));

            var knights = new Path(currentKing.CurrentPosition,
                new PathType[]
                {
                    PathType.Knight
                })
                .Where(x => chessBoard[x.Single()] != null &&
                chessBoard[x.Single()].PlayerColour == Piece.Opponent(turnToMove) &&
                (chessBoard[x.Single()].PieceType == PieceType.Knight));

            return diagonalAttacks.Any() || verticalHorizontalAttacks.Any() || knights.Any();
        }

        private bool KingCheckMateStatus()
        {
            return false;
        }

        private Piece FindKing() => 
            chessBoard.GetAllPieces().Where(x => x != null && 
            x.PieceType == PieceType.King && 
            x.PlayerColour == turnToMove).Single();

        public bool IsChecked
        {
            get => KingCheckStatus();
        }

        public bool IsCheckMated
        {
            get => KingCheckMateStatus();
        }
    }
}
