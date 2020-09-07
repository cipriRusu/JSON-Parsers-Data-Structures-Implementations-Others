using ChessGame.Interfaces;
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
        public IEnumerable<IPiece> Performers { get; private set; }

        public void GetCurrent(IUserMove move)
        {
            Performers = AllPieces().Where(x => x != null && x.CanPerform(move, this));

            move.CallBack(MoveTo);

            move.Perform(this);
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