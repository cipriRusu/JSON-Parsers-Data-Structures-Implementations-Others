using ChessGame.Paths;
using ChessMoves.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChessMoves
{
    public abstract class PathGenerator
    {
        public PathGenerator(IPiece piece, params PathType[] paths)
        {
            StartIndex = piece.Index;
            PathTypes = paths;
            PlayerColour = piece.Player;
        }
        internal (int, int) StartIndex { get; }
        internal Player PlayerColour { get; }
        internal readonly IEnumerable<PathType> PathTypes;
        public virtual IEnumerable<IPath> GetEnumerator()
        {
            yield return null;
        }
    }
}