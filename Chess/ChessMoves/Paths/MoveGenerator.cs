using ChessMoves;
using ChessMoves.Paths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Paths
{
    public class MoveGenerator : PathGenerator
    {
        public MoveGenerator(IPiece piece, params PathType[] paths) : base(piece, paths) { }

        public override IEnumerable<IPath> GetEnumerator()
        {
            foreach (var move in PathTypes)
            {
                switch (move)
                {
                    case PathType.RowsAndColumns:

                        foreach (var path in new RownColumnPaths(StartIndex))
                        {
                            yield return new MovePath(path, StartIndex);
                        }

                        break;
                    case PathType.Diagonals:

                        foreach (var path in new DiagonalPaths(StartIndex))
                        {
                            yield return new MovePath(path, StartIndex);
                        }

                        break;
                    case PathType.Knight:

                        foreach (var path in new KnightPath(StartIndex))
                        {
                            yield return new MovePath(path, StartIndex);
                        }

                        break;
                    case PathType.King:

                        foreach (var path in new KingPaths(StartIndex))
                        {
                            yield return new MovePath(path, StartIndex);
                        }

                        break;
                    case PathType.Pawn:

                        foreach (var path in new PawnPath(StartIndex, PlayerColour))
                        {
                            yield return new MovePath(path, StartIndex);
                        }

                        break;
                    default:
                        throw new Exception("Path type not handled for move case");
                }
            }
        }
    }
}
