using ChessGame.Interfaces;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class Board : IBoard, IMoveCheck, IMovePerform
    { 
        private const int ChessboardSize = 8;
        private IPiece[,] board = new IPiece[ChessboardSize, ChessboardSize];
        public Board(IPiece[,] board) => this.board = board;
        public bool IsClear(IPath path) => path.Path.All(x => board[x.Item1, x.Item2] == null);
        public bool IsCheck { get; private set; }
        public bool IsCheckMate { get; private set; }
        public IEnumerable<IPiece> Performers { get; private set; }

        public void GetCurrent(IUserMove move)
        {
            Performers = AllPieces().Where(x => 
            x != null && 
            x.CanPerform(move, this) && 
            new MoveConstraintValidator(x, move).IsValid);

            move.CallBack(MoveTo);

            move.Perform(this);

            if (IsCheck == false && move is KingCheckUserMove)
            {
                var performer = board[move.Index.Item1, move.Index.Item2];

                var pathToKing = performer.Captures.Where(x => 
                x != null &&
                board[x.End.Item1, x.End.Item2] is King && 
                board[x.End.Item1, x.End.Item2].Player != move.Player);
                
                try
                {
                    var isClear = IsClear(pathToKing.Single());
                    IsCheck = pathToKing != null && isClear;
                }
                catch (Exception)
                {
                    throw new UserMoveException(move, "Invalid check move");
                }
            }

            if(IsCheckMate == false && move is KingCheckMateUserMove)
            {
                var performer = board[move.Index.Item1, move.Index.Item2];

                var pathToKing = performer.Captures.Where(x =>
                x != null &&
                board[x.End.Item1, x.End.Item2] is King &&
                board[x.End.Item1, x.End.Item2].Player != move.Player);

                IsCheckMate = true;
            }

            if(IsCheck == true && !(move is KingCheckUserMove)) {

                var currentKing = AllPieces().Where(x =>
                x != null &&
                x is King &&
                x.Player == move.Player).Single();

                var opponents = AllPieces().Where(x =>
                x != null &&
                x.Player != move.Player);
                
                IsCheck = false;
            }
        }

        private void MoveTo(IPiece piece, (int, int) Target)
        {
            board[Target.Item1, Target.Item2] = piece;
            board[piece.Index.Item1, piece.Index.Item2] = null;
        }

        private IEnumerable<IPiece> AllPieces()
        {
            var allIndices = Enumerable.Range(0, ChessboardSize);
    
            return allIndices.SelectMany(x => allIndices.Select(y => board[x, y]));
        }
    }
}