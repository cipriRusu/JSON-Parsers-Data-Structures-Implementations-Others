using ChessMoves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChessGame.Paths
{
    public class CaptureGenerator : PathGenerator
    {
        public CaptureGenerator(IPiece piece, params PathType[] paths) : base(piece, paths) { }

        public override IEnumerable<IPath> GetEnumerator()
        {
            foreach (var move in PathTypes)
            {
                switch (move)
                {
                    case PathType.RowsAndColumns:

                        foreach (var path in new RownColumnPaths(StartIndex))
                        {
                            yield return new CapturePath(path, StartIndex);
                        }

                        break;
                    case PathType.Diagonals:

                        foreach (var path in new DiagonalPaths(StartIndex))
                        {
                            yield return new CapturePath(path, StartIndex);
                        }

                        break;
                    case PathType.Knight:

                        foreach (var path in new KnightPath(StartIndex))
                        {
                            yield return new CapturePath(path, StartIndex);
                        }

                        break;
                    case PathType.King:

                        foreach (var path in new KingPaths(StartIndex))
                        {
                            yield return new CapturePath(path, StartIndex);
                        }

                        break;

                    case PathType.PawnCapture:

                        foreach (var path in new PawnCapturePath(StartIndex, PlayerColour))
                        {
                            yield return new CapturePath(path, StartIndex);
                        }

                        break;
                    default:
                        throw new Exception("Capture generator not handling current path type");
                }
            }
        }
    }
}
