using System;

namespace ChessMoves
{
    internal class UserMoveException : Exception
    {
        private UserMove move;

        public UserMoveException(string message) { }

        public UserMoveException(UserMove move, string message) : base(message)
        {
            this.move = move;
        }
    }
}