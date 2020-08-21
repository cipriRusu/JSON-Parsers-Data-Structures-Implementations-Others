using System;

namespace ChessMoves
{
    internal class UserMoveException : Exception
    {
        private IUserMove move;

        public UserMoveException(IUserMove move, string message) : base(message)
        {
            this.move = move;
        }
    }
}