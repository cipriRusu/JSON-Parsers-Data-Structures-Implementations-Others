using ChessMoves.Paths;

namespace ChessGame.Interfaces
{
    public interface IOperation
    {
        bool IsClear(IPath path);
    }
}
