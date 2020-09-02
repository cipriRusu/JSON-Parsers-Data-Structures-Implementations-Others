using ChessMoves.Paths;

namespace ChessMoves
{
    public interface IBoard
    {
        void Perform(IUserMove move);
    }
}
