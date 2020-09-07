using ChessMoves.Paths;

namespace ChessGame.Interfaces
{
    public interface IMoveCheck
    {
        bool IsClear(IPath path);
    }
}
