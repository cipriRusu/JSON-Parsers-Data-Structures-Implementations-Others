using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves
{
    public interface IPath : IEnumerable<IEnumerable<(int, int)>> { }
}
