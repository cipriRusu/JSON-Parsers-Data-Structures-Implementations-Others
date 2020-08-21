using ChessGame;
using ChessGame.Moves;
using ChessGame.MoveValidator;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class Board : IBoard
    {
        private const int ChessboardSize = 8;
        private IPiece[,] board = new IPiece[ChessboardSize, ChessboardSize];
        public Board(IPiece[,] board) => this.board = board;
        public IPiece this[int first, int second] => board[first, second];

        public void Perform(IUserMove move)
        {
            if (move is MoveUserMove)
                PerformMove(move);
            else if (move is CaptureUserMove)
                PerformCapture(move);
        }

        private void PerformMove(IUserMove move)
        {
            var legalPiece = new LegalPiece(GetAllPieces()).GetMovablePiece(move, out IPath path);

            if(new MoveValidator(board, move).ValidatePath(path))
            {
                new Move(board, legalPiece).ApplyMove(move);
            }
        }

        private void PerformCapture(IUserMove move) => PerformMove(move);

        private IEnumerable<IPiece> GetAllPieces() =>
            Enumerable.Range(0, ChessboardSize).SelectMany(i =>
            Enumerable.Range(0, ChessboardSize).Select(j => board[i, j]));
    }
}