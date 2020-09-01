using ChessGame.Interfaces;
using ChessMoves.Paths;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class Board : IBoard, IBoardOperation
    { 
        private const int ChessboardSize = 8;
        private IPiece[,] board = new IPiece[ChessboardSize, ChessboardSize];
        public Board(IPiece[,] board) => this.board = board;

        public bool IsClear(IPath path, int frontSkip = 0, int endSkip = 0) => 
            path.Path.Skip(frontSkip)
                     .SkipLast(endSkip)
                     .All(x => board[x.Item1, x.Item2] == null);

        public void Perform(IUserMove move)
        {

        }

        private IEnumerable<IPiece> AllPieces()
        {
            for (int i = 0; i < ChessboardSize; i++)
            {
                for (int j = 0; j < ChessboardSize; j++)
                {
                    yield return board[i, j];
                }
            }
        }
    }
}