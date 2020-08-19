using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.Paths
{
    public interface IPath
    {
        (int, int) Start { get; }
        (int, int) End { get; }
        IEnumerable<(int, int)> Path { get; }
    }
}
