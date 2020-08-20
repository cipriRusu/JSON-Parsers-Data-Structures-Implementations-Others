using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    interface IMovable
    {
        IEnumerable<IPath> Moves();
        IEnumerable<IPath> Captures();
    }
}
