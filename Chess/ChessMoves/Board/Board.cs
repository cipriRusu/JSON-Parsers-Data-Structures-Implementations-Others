using ChessGame.Interfaces;
using ChessMoves.Paths;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class Board : IBoard, IBoardCheck
    { 
        private const int ChessboardSize = 8;
        private IPiece[,] board = new IPiece[ChessboardSize, ChessboardSize];
        public Board(IPiece[,] board) => this.board = board;
        public bool IsClear(IPath path) => path.Path.All(x => board[x.Item1, x.Item2] == null);

        public void Perform(IUserMove move)
        {
            var performers = AllPieces().Where(x => x != null && x.CanPerform(move, this));
        }

        private IEnumerable<IPiece> AllPieces()
        {
            var allIndices = Enumerable.Range(0, ChessboardSize);

            return allIndices.SelectMany(x => allIndices.Select(y => board[x, y]));
        }
    }
}