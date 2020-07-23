namespace ChessMoves
{
    internal class Promotion
    {
        private ChessBoard chessBoard;
        private UserMove move;
        private int LastFileBlack = 7;
        private int LastFileWhite = 0;

        public Promotion(ChessBoard chessBoard, UserMove move)
        {
            this.chessBoard = chessBoard;
            this.move = move;

            PromotionHandling();
        }

        private void PromotionHandling()
        {
            var promotionTo = move.NotationIndex[move.NotationIndex.Length - 1];
            var currentPosition = new RankAndFile(move.MoveIndex).GetRankAndFile;

            if(promotionTo == 'Q' && chessBoard[move.MoveIndex].PieceType == PieceType.Pawn)
            {
                if (move.MoveIndex.Item1 == LastFileWhite || 
                    move.MoveIndex.Item1 == LastFileBlack)
                {
                    chessBoard.PromoteTo(chessBoard[move.MoveIndex], new Queen(currentPosition, move.PlayerColor));
                }
            }
            else if(promotionTo == 'B' && chessBoard[move.MoveIndex].PieceType == PieceType.Pawn)
            {
                if (move.MoveIndex.Item1 == LastFileWhite ||
                    move.MoveIndex.Item1 == LastFileBlack)
                {
                    chessBoard.PromoteTo(chessBoard[move.MoveIndex], new Bishop(currentPosition, move.PlayerColor));
                }
            }
            else if (promotionTo == 'K' && chessBoard[move.MoveIndex].PieceType == PieceType.Pawn)
            {
                if (move.MoveIndex.Item1 == LastFileWhite ||
                    move.MoveIndex.Item1 == LastFileBlack)
                {
                    chessBoard.PromoteTo(chessBoard[move.MoveIndex], new Knight(currentPosition, move.PlayerColor));
                }
            }
            else if (promotionTo == 'R' && chessBoard[move.MoveIndex].PieceType == PieceType.Pawn)
            {
                if (move.MoveIndex.Item1 == LastFileWhite ||
                    move.MoveIndex.Item1 == LastFileBlack)
                {
                    chessBoard.PromoteTo(chessBoard[move.MoveIndex], new Rock(currentPosition, move.PlayerColor));
                }
            }
        }
    }
}