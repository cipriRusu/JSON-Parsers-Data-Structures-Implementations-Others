using ChessMoves.Paths;

namespace ChessMoves
{
    public interface IBoard
    {
        void Perform(IUserMove move);
        bool IsClear(IPath path, int frontSkip = 0, int endSkip = 0);
    }
}
