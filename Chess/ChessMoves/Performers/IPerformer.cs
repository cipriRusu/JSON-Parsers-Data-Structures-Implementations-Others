using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IPerformer
    {
        IEnumerable<IPath> Moves();
        IEnumerable<IPath> Captures();
    }
}
