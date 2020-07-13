using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace ChessMoves
{
    [Serializable]
    internal class King : Piece
    {
        public King((int, int) currentPosition, Player playerColour) :
            base(currentPosition, playerColour)
        { base.PieceType = PieceType.King; }

        public King(string chessBoardIndex, Player playerColour) :
            base(chessBoardIndex, playerColour)
        {
            base.PieceType = PieceType.King;
            base.CurrentPosition = base.customIndex.GetMatrixIndex(chessBoardIndex);
            base.PlayerColour = playerColour;
        }

        public override Path GetLegalMoves() => new Path(CurrentPosition, new PathType[] { PathType.King });

        internal override bool IsChecked(ChessBoard chessBoard, Player player)
        {
            switch (player)
            {
                case Player.Black:
                    return CheckValidator(Player.White, chessBoard);
                case Player.White:
                    return CheckValidator(Player.Black, chessBoard);
                default:
                    return false;
            }
        }

        private bool CheckValidator(Player opponent, ChessBoard chessBoard)
        {
            var diags = new Path(CurrentPosition, new PathType[] { PathType.Diagonals })
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                (chessBoard.IsPiece(x.Last(), PieceType.Queen, opponent) ||
                chessBoard.IsPiece(x.Last(), PieceType.Bishop, opponent)));

            var rowsAndColumns = new Path(CurrentPosition, new PathType[] { PathType.RowsAndColumns })
                .Where(x =>
                chessBoard.IsPathClear(x.Skip(1).SkipLast(1)) &&
                (chessBoard.IsPiece(x.Last(), PieceType.Rock, opponent) ||
                chessBoard.IsPiece(x.Last(), PieceType.Queen, opponent)));

            var knight = new Path(CurrentPosition, new PathType[] { PathType.Knight })
                .Where(x => chessBoard.IsPiece(x.Single(), PieceType.Knight, opponent));

            return diags.Any() || rowsAndColumns.Any() || knight.Any() || PawnCheck(chessBoard);
        }

        private bool PawnCheck(ChessBoard chessBoard)
        {
            if (PlayerColour == Player.White)
            {
                if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1))
                {
                    if (chessBoard
                        .IsPiece((CurrentPosition.Item1 - 1, CurrentPosition.Item2 - 1),
                        PieceType.Pawn,
                        Piece.Opponent(base.PlayerColour)))
                    {
                        return true;
                    }
                }
                if (CheckIndexes(CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 1))
                {
                    if (chessBoard.IsPiece((CurrentPosition.Item1 - 1, CurrentPosition.Item2 + 1),
                        PieceType.Pawn,
                        Piece.Opponent(base.PlayerColour)))
                    {
                        return true;
                    }
                }
            }

            if (PlayerColour == Player.Black)
            {
                if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1))
                {
                    if (chessBoard.IsPiece((CurrentPosition.Item1 + 1, CurrentPosition.Item2 - 1),
                        PieceType.Pawn,
                        Piece.Opponent(base.PlayerColour)))
                    {
                        return true;
                    }
                }

                if (CheckIndexes(CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1))
                {
                    if (chessBoard.IsPiece((CurrentPosition.Item1 + 1, CurrentPosition.Item2 + 1),
                        PieceType.Pawn,
                        Piece.Opponent(base.PlayerColour)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}