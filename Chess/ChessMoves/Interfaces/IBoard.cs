using ChessMoves.Paths;

namespace ChessMoves
{
    public interface IBoard
    {
        void GetCurrent(IUserMove move);
        bool IsCheck { get; }
        bool IsCheckMate { get; }
    }
}
