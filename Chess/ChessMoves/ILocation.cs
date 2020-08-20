using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface ILocation
    {
        (int, int) Index { get; }
        char File { get; }
        char Rank { get; }
    }
}
