using ChessMoves.Paths;

namespace ChessGame.Interfaces
{
    public interface IBoardCheck
    {
        bool IsClear(IPath path);
    }
}
