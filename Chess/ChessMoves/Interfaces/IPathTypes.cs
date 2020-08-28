using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IPathTypes
    {
        public IEnumerable<IPath> Moves { get; }
        public IEnumerable<IPath> Captures { get; }
    }
}
