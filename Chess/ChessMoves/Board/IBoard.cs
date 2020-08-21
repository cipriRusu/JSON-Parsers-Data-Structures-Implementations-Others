using ChessMoves.Moves;
using ChessMoves.Paths;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IBoard : IEnumerable<IPiece>
    {
        public IPiece this[int first, int second] { get; }
        void Perform(IUserMove move);
        bool IsPathClear(IPath path);
    }
}
