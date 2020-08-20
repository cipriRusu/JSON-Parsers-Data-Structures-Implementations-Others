using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves
{
    public class AttackStatus
    {
        private IBoard boardState;
        private IPiece chessPiece;
        public bool IsAttacked => IsCurrentAttacked();
        public bool IsCheckMated => IsCurrentCheckMate();

        public AttackStatus(IBoard boardState, IPiece chessPiece)
        {
            this.boardState = boardState;
            this.chessPiece = chessPiece;
        }

        public bool IsCurrentCheckMate()
        {
            var legalMoves = boardState.AllKingMoves(chessPiece);

            foreach (var move in legalMoves)
            {
                var currentBoardState = boardState.DeepClone();

                currentBoardState.PerformMove(move);

                if (!new CurrentPlayerStatus(chessPiece.PlayerColour, currentBoardState).IsChecked)
                {
                    return false;
                }
            }

            return legalMoves.Count() > 0;
        }

        public bool IsCurrentAttacked()
        {
            var diagonalAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Queen, PieceType.Bishop },
                PathType.Diagonals);

            var verticalHorizontalAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Queen, PieceType.Rock },
                PathType.RowsAndColumns);

            var knightAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Knight },
                PathType.Knight);

            var pawnAttacks =
                ValidAttacks(chessPiece,
                new PieceType[] { PieceType.Pawn },
                PathType.PawnCapture);

            return diagonalAttacks || verticalHorizontalAttacks || knightAttacks || pawnAttacks;
        }

        public bool IsCurrentMoveAttacked(IUserMove move)
        {
            var currentBoardState = boardState.DeepClone();

            //currentBoardState.PerformMove(chessPiece, move);

            return new CurrentPlayerStatus(chessPiece.PlayerColour, currentBoardState).IsChecked;
        }


        private bool ValidAttacks(IPiece currentKing, PieceType[] attackers, params PathType[] pathTypes) => 
            new PathGenerator(currentKing, pathTypes).GetEnumerator()
                .Where(x => boardState[x.End] != null)
                .Where(x => boardState.IsCapturePathClear(x))
                .Where(x => boardState[x.End].PlayerColour == Piece.Opponent(currentKing.PlayerColour))
                .Where(x => attackers.Contains(boardState[x.End].PieceType)).Any();
    }
}
