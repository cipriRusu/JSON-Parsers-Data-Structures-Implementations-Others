using ChessMoves.Paths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChessMoves
{
    public class PathGenerator
    {
        public PathGenerator(IPiece piece, params PathType[] paths)
        {
            StartIndex = piece.CurrentPosition;
            PathTypes = paths;
            PlayerColour = piece.PlayerColour;
        }
        private (int, int) StartIndex;
        private Player PlayerColour { get; }

        private readonly IEnumerable<PathType> PathTypes;

        public IEnumerable<IPath> GetEnumerator()
        {
            foreach (var type in PathTypes)
            {
                switch (type)
                {
                    case PathType.RowsAndColumns:

                        foreach (var currentPath in new RownColumnPaths(StartIndex))
                        {
                            yield return currentPath;
                        }

                        break;

                    case PathType.Diagonals:

                        foreach (var currentPath in new DiagonalPaths(StartIndex))
                        {
                            yield return currentPath;
                        }

                        break;

                    case PathType.Knight:

                        foreach (var currentPath in new KnightPath(StartIndex))
                        {
                            yield return currentPath;
                        }

                        break;

                    case PathType.King:

                        foreach (var currentPath in new KingPaths(StartIndex))
                        {
                            yield return currentPath;
                        }

                        break;

                    case PathType.Pawn:

                        foreach (var currentPath in new PawnPath(StartIndex, PlayerColour))
                        {
                            yield return currentPath;
                        }

                        break;

                    case PathType.PawnCapture:

                        foreach (var currentPath in new PawnCapturePath(StartIndex, PlayerColour))
                        {
                            yield return currentPath;
                        }

                        break;
                }
            }
        }
    }
}