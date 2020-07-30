using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMoves.Moves
{
    public class QueenCastlingUserMove : UserMove, IUserMove
    {
        private int CastlingPathLength = 5;
        public QueenCastlingUserMove(string input, Player playerTurn) : base(input, playerTurn) { }

        public void GetCurrentState(IBoardState board)
        {
            CastlingExceptions(board);

            var castlingPath = CastlingPath(GetKing(board));

            if (!castlingPath.Skip(1).SkipLast(2).Any(x => new CurrentPlayerStatus(PlayerColor, board).KingPositionCheckStatus(x)))
            {
                var king = GetKing(board);
                var rock = board[castlingPath.Last()];

                king.PerformCastlingMove((king.CurrentPosition.Item1, king.CurrentPosition.Item2 - 2), board);
                rock.PerformCastlingMove((rock.CurrentPosition.Item1, rock.CurrentPosition.Item2 + 3), board);
            }
            else
            {
                throw new UserMoveException(this, "Castling move illegal due to CheckPassing");
            }
        }

        private IChessPiece GetKing(IBoardState board) =>
            board.GetAllPieces().Where(x =>
                                            x != null &&
                                            x.PieceType == PieceType.King &&
                                            x.PlayerColour == PlayerColor)
                                .Single();

        private IEnumerable<(int, int)> CastlingPath(IChessPiece king) =>
            Enumerable.Range(0, CastlingPathLength)
                      .Reverse()
                      .Select(x => (king.CurrentPosition.Item1, x));

        private void CastlingExceptions(IBoardState board)
        {
            if (GetKing(board).IsMoved)
            {
                throw new UserMoveException(this, "Castling move illegal due to moved King");
            }

            if (!board.IsPathClear(CastlingPath(GetKing(board)).Skip(1).SkipLast(1)))
            {
                throw new UserMoveException(this, "Castling move illegal due to unclear Path");
            }

            if (board[CastlingPath(GetKing(board)).Last()] == null)
            {
                throw new UserMoveException(this, "No castling piece available");
            }

            if (board[CastlingPath(GetKing(board)).Last()].IsMoved)
            {
                throw new UserMoveException(this, "Castling move illegal due to moved Rock");
            }
        }
    }
}
