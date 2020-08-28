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
        public delegate void Move(IPath path);
        public Board(IPiece[,] board) => this.board = board;
        public IPiece this[(int, int) input]
        {
            get => board[input.Item1, input.Item2];
            set => board[input.Item1, input.Item2] = value; 
        }

        public IUserMove CurrentMove { get; private set; }
        public IEnumerable<IPiece> CurrentPieces { get; private set; }
        public bool IsClear(IPath path, int frontSkip = 0, int endSkip = 0) => 
            path.Path.Skip(frontSkip)
                     .SkipLast(endSkip)
                     .All(x => board[x.Item1, x.Item2] == null);

        public void Perform(IUserMove move)
        {
            CurrentMove = move;

            CurrentPieces = AllPieces().Where(x => x != null).Where(x => x.CanPerform(this));

            CurrentMove.Move(this);
        }

        public void Apply(IPiece piece, IUserMove move)
        {
            this[move.Index] = this[piece.Index];
            this[piece.Index] = null;
            this[move.Index].Update(move);
        }

        public bool IsOpponent(IPath path, Player player) => this[path.End].PlayerColour != player;

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