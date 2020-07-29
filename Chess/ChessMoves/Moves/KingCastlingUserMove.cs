using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChessMoves.Moves
{
    public class KingCastlingUserMove : UserMove, IUserMove
    {
        private int CastlingPathLength = 4;
        public KingCastlingUserMove(string input, Player turnToMove) : base(input, turnToMove) { }

        public void PerformMoveType(ChessBoard board)
        {
            CastlingExceptions(board);

            var castlingPath = CastlingPath(GetKing(board));

            if (!castlingPath.Skip(1).SkipLast(1).Any(x => new CurrentPlayerStatus(PlayerColor, board).KingPositionCheckStatus(x)))
            {
                var king = GetKing(board);
                var rock = board[castlingPath.Last()];

                king.PerformCastlingMove((king.CurrentPosition.Item1, king.CurrentPosition.Item2 + 2), board);
                rock.PerformCastlingMove((rock.CurrentPosition.Item1, rock.CurrentPosition.Item2 - 2), board);
            }
            else
            {
                throw new UserMoveException(this, "Castling move illegal due to CheckPassing");
            }
        }



        private void CastlingExceptions(ChessBoard board)
        {
            if (GetKing(board).IsMoved)
            {
                throw new UserMoveException(this, "Castling move illegal due to moved King");
            }

            if (!board.IsPathClear(CastlingPath(GetKing(board)).Skip(1).SkipLast(1)))
            {
                throw new UserMoveException(this, "Castling move illegal due to unclear Path");
            }

            if(board[CastlingPath(GetKing(board)).Last()] == null)
            {
                throw new UserMoveException(this, "No castling piece available");
            }

            if (board[CastlingPath(GetKing(board)).Last()].IsMoved)
            {
                throw new UserMoveException(this, "Castling move illegal due to moved Rock");
            }
        }

        private IEnumerable<(int, int)> CastlingPath(IChessPiece king) =>
            Enumerable.Range(king.CurrentPosition.Item2,
                             CastlingPathLength)
                        .Select(x => (king.CurrentPosition.Item1, x));

        private IChessPiece GetKing(ChessBoard board) =>
            board.GetAllPieces().Where(x =>
                                            x != null &&
                                            x.PieceType == PieceType.King &&
                                            x.PlayerColour == PlayerColor)
                                .Single();
    }
}
