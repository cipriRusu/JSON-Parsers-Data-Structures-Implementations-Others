using ChessGame;

namespace ChessMoves
{
    public interface IRock : IPiece, ICastable
    {
        public bool IsKingSide => Index.Item2 >= 4;
    }
}