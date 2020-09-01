using ChessMoves.Paths;

namespace ChessGame.Interfaces
{
    public interface IBoardOperation
    {
        bool IsClear(IPath path, int frontSkip = 0, int endSkip = 0);
    }
}
