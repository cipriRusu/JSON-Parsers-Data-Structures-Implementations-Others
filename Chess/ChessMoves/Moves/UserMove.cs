using ChessGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    public class UserMove : IUserMove
    {
        public Type PieceType { get; private set; }
        public (int, int) Index { get; private set; }
        public string Notation { get; private set; }
        public char File { get; private set; }
        public char Rank { get; private set; }
        public Player Player { get; private set; }
        internal Action<IPiece, (int, int)> Action { get; set; }
        public void CallBack(Action<IPiece, (int, int)> action) => this.Action = action;

        internal UserMove(string input, Player player)
        {
            Notation = input;
            Player = player;
            UserMoveExceptions(input);
            GetType(input);
            GetSource(string.Concat(input.TakeLast(2)));
            GetOrigin(input[0..^2]);
        }

        public virtual bool CanHandle(IPieceState pieceCheck, IMoveCheck boardCheck) => false;
        public virtual void Perform(IMovePerform boardMove) { }

        private void GetSource(string source)
        {
            if (source.All(x => IsRank(x) || IsFile(x)))
            {
                Index = new Index().GetIndex(source);
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
        private void GetType(string input)
        {
            PieceType = (input.First()) switch
            {
                'K' => typeof(King),
                'Q' => typeof(Queen),
                'R' => typeof(Rock),
                'B' => typeof(Bishop),
                'N' => typeof(Knight),
                _ => typeof(Pawn),
            };
        }
        private void UserMoveExceptions(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new UserMoveException(this, "Current user input is empty!");
            }
        }
    }
}
