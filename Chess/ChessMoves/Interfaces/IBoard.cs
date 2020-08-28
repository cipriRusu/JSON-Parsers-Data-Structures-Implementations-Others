using ChessMoves.Moves;
using ChessMoves.Paths;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoard
    {
        public IPiece this[(int, int) input] { get; }
        void Perform(IUserMove move);
        bool IsClear(IPath path, int frontSkip = 0, int endSkip = 0);
    }
}
