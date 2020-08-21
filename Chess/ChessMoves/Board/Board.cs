using ChessGame;
using ChessGame.Moves;
using ChessGame.MoveValidator;
using ChessMoves.Moves;
using ChessMoves.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ChessMoves
{
    public class Board : IBoard
    {
        private const int ChessboardSize = 8;
        private IPiece[,] board = new IPiece[ChessboardSize, ChessboardSize];
        public Board(IPiece[,] board) => this.board = board;
        public IPiece this[int first, int second] => board[first, second];
        public bool IsPathClear(IPath path) => path.Path.Skip(1).SkipLast(1).All(x => board[x.Item1, x.Item2] == null);
        public void Perform(IUserMove move)
        {
            if (move is MoveUserMove)
                PerformMove(move);
            else if (move is CaptureUserMove)
                PerformCapture(move);
            else if (move is KingCheckUserMove)
                PerformCheck(move);
            else if (move is KingCheckMateUserMove)
                PerformCheckMate(move);
        }

        private void PerformMove(IUserMove move)
        {
            var legalPiece = new LegalPiece(this).GetMovablePiece(move, out IPath path);

            if (new MoveValidator(board, move).ValidatePath(path))
            {
                new Move(board, legalPiece).ApplyMove(move);
            }
        }

        private void PerformCapture(IUserMove move) => PerformMove(move);

        private void PerformCheck(IUserMove move)
        {
            var internalMove = new MoveType(move.NotationIndex, move.PlayerColor).Move;
            Perform(internalMove);
        }

        private void PerformCheckMate(IUserMove move)
        {
            var internalMove = new MoveType(move.NotationIndex, move.PlayerColor).Move;
            Perform(internalMove);
        }

        public IEnumerator<IPiece> GetEnumerator()
        {
            for(int i = 0; i < ChessboardSize; i++)
            {
                for(int j = 0; j < ChessboardSize; j++)
                {
                    yield return board[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}