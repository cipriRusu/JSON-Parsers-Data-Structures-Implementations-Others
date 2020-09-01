namespace ChessMoves
{
    public interface IGame
    {
        Player TurnToMove { get; set; }
        bool IsCheckMate { get; }
        bool IsCheck { get; }
    }
}
