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
    public class PathGenerator
    {
        public PathGenerator(IPiece piece, params PathType[] paths)
        {
            StartIndex = piece.Index;
            PathTypes = paths;
            PlayerColour = piece.Player;
        }
        private (int, int) StartIndex { get; }
        private Player PlayerColour { get; }

        private readonly IEnumerable<PathType> PathTypes;

        public IEnumerable<IPath> GetEnumerator()
        {
            foreach (var type in PathTypes)
            {
                switch (type)
                {
                    case PathType.RowsAndColumns:

                        foreach(var path in new RownColumnPaths(StartIndex))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;

                    case PathType.Diagonals:

                        foreach (var path in new DiagonalPaths(StartIndex))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;

                    case PathType.Knight:

                        foreach (var path in new KnightPath(StartIndex))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;

                    case PathType.King:

                        foreach (var path in new KingPaths(StartIndex))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;

                    case PathType.Pawn:

                        foreach (var path in new PawnPath(StartIndex, PlayerColour))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;

                    case PathType.PawnCapture:

                        foreach (var path in new PawnCapturePath(StartIndex, PlayerColour))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;

                    case PathType.KingSideCastling:

                        foreach(var path in new KingSideCastlingPath(StartIndex, PlayerColour))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;

                    case PathType.QueenSideCastling:

                        foreach(var path in new QueenSideCastlingPath(StartIndex, PlayerColour))
                        {
                            yield return new Path(path, StartIndex);
                        }

                        break;
                }
            }
        }
    }
}