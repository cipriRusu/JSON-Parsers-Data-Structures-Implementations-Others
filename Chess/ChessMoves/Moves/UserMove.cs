using ChessMoves.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ChessMoves
{
    public class UserMove : IUserMove
    {
        public Type PieceType { get; private set; }
        public (int, int) Index { get; private set; }
        protected string NotationIndex { get; private set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public void GetCurrentState(IBoard board) {}

        public bool ValidateDestination(IPiece piece, IBoard boardState) => false;

        public Player PlayerColor { get; private set; }

        internal UserMove(string input, Player playerTurn)
        {
            NotationIndex = input;
            PlayerColor = playerTurn;
            UserMoveInputExceptions(input);
            GetPieceType(input);
            GetSource(string.Concat(input.TakeLast(2)));
            GetOrigin(input[0..^2]);
        }

        public UserMove((int, int) movementLocation, Player playerTurn)
        {
            //Custom constructor for checking king status
            PieceType = typeof(King);
            PlayerColor = playerTurn;
            Index = movementLocation;
        }

        private void GetSource(string source)
        {
            if (source.All(x => IsRank(x) || IsFile(x)))
            {
                Index = new Index().GetMatrixIndex(source);
            }
        }

        private void GetOrigin(IEnumerable<char> origin)
        {
            foreach (var element in origin)
            {
                if (IsRank(element)) { Rank = element; }
                if (IsFile(element)) { File = element; }
            }
        }
        private bool IsRank(char c) => "12345678".Contains(c);
        private bool IsFile(char c) => "abcdefgh".Contains(c);
        private void GetPieceType(string input)
        {
            switch (input.First())
            {
                case 'K':
                    PieceType = typeof(King);
                    break;
                case 'Q':
                    PieceType = typeof(Queen);
                    break;
                case 'R':
                    PieceType = typeof(Rock);
                    break;
                case 'B':
                    PieceType = typeof(Bishop);
                    break;
                case 'N':
                    PieceType = typeof(Knight);
                    break;
                default:
                    PieceType = typeof(Pawn);
                    break;
            }
        }
        private static void UserMoveInputExceptions(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new UserMoveException("Current user input is empty!");
            }
        }

        internal void CheckVerification(IBoard board)
        {
            if (new CurrentPlayerStatus(PlayerColor, board).IsChecked)
            {
                throw new UserMoveException(this, "Move invalid");
            }
            else
            {

            }
        }

        public void MoveAndPieceExceptions(IUserMove move, IEnumerable<IPiece> pieces)
        {
            if (!pieces.Any())
            {
                throw new UserMoveException(this, "No piece found that can handle current user input");
            }
            if (pieces.Count() > 1)
            {
                throw new PieceException(move, pieces, "Multiple pieces found that can perform current move due to ambiguous input");
            }
        }
    }
}
