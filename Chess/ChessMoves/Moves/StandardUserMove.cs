namespace ChessMoves.Moves
{
    public class StandardUserMove : UserMove, IUserMove
    {
        public StandardUserMove(string input, Player playerTurn) : base(input, playerTurn) { }
    }
}
