using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessMoves
{
    [Serializable]
    public class ChessBoard
    {
        public ChessBoard() => InitializeBoard();
        
        public readonly static int CHESSBOARD_SIZE = 8;

        private Piece[,] board = new Piece[CHESSBOARD_SIZE, CHESSBOARD_SIZE];

        public Player TurnToMove { get; private set; } = Player.White;
        public bool IsCheckMate { get; private set; }
        public bool IsCheck { get; private set; }

        public Piece this[int i, int j] => board[i, j];

        internal void Moves(IEnumerable<string> userMoves)
        {
            foreach (var move in ConvertMoves(userMoves))
            {
                Move(move);
            }
        }

        private void Move(UserMove move)
        {
            var selectedPiece = new PieceSelector(move, this).GetValidPiece();
            PieceNotFoundException(selectedPiece);
            PerformMove(selectedPiece.CurrentPosition, move.MoveIndex);
        }

        private static void PieceNotFoundException(Piece selectedPiece)
        {
            if (selectedPiece == null)
            {
                throw new ArgumentException("No valid piece was found that could perform the requested move");
            }
        }

        internal bool IsPiece((int, int) currentPosition, PieceType pieceType, Player player)
        {
            return
                board[currentPosition.Item1, currentPosition.Item2] != null &&
                board[currentPosition.Item1, currentPosition.Item2].CurrentPosition == currentPosition &&
                board[currentPosition.Item1, currentPosition.Item2].PieceType == pieceType &&
                board[currentPosition.Item1, currentPosition.Item2].PlayerColour == player;
        }

        private void PerformMove((int, int) source, (int, int) destination)
        {
            board[destination.Item1, destination.Item2] = board[source.Item1, source.Item2];
            board[destination.Item1, destination.Item2].Update(destination);
            board[source.Item1, source.Item2] = null;

            SwitchTurn();
        }

        public bool IsPathClear(IEnumerable<(int, int)> input) =>
            input.All(x => board[x.Item1, x.Item2] == null);

        private void SwitchTurn()
        {
            switch (TurnToMove)
            {
                case Player.White:
                    TurnToMove = Player.Black;
                    break;
                case Player.Black:
                    TurnToMove = Player.White;
                    break;
            }
        }

        private IEnumerable<UserMove> ConvertMoves(IEnumerable<string> input)
        {
            var output = new List<UserMove>();

            foreach (var move in input.Select(x => x.Split(' ')))
            {
                switch (move.Count())
                {
                    case 1:
                        output.Add(new UserMove(move.First()) { PlayerColor = Player.White });
                        break;
                    case 2:
                        output.Add(new UserMove(move.First()) { PlayerColor = Player.White });
                        output.Add(new UserMove(move.Last()) { PlayerColor = Player.Black });
                        break;
                    default:
                        throw new ArgumentException("Input not properly formated");
                }
            }

            return output;
        }

        private void InitializeBoard()
        {
            InitializeWhite();
            InitializeBlack();
        }

        private void InitializeBlack()
        {
            board[0, 0] = new Rock("a8", Player.Black);
            board[0, 1] = new Knight("b8", Player.Black);
            board[0, 2] = new Bishop("c8", Player.Black);
            board[0, 3] = new Queen("d8", Player.Black);
            board[0, 4] = new King("e8", Player.Black);
            board[0, 5] = new Bishop("f8", Player.Black);
            board[0, 6] = new Knight("g8", Player.Black);
            board[0, 7] = new Rock("h8", Player.Black);

            board[1, 0] = new Pawn("a7", Player.Black);
            board[1, 1] = new Pawn("b7", Player.Black);
            board[1, 2] = new Pawn("c7", Player.Black);
            board[1, 3] = new Pawn("d7", Player.Black);
            board[1, 4] = new Pawn("e7", Player.Black);
            board[1, 5] = new Pawn("f7", Player.Black);
            board[1, 6] = new Pawn("g7", Player.Black);
            board[1, 7] = new Pawn("h7", Player.Black);
        }

        private void InitializeWhite()
        {
            board[7, 0] = new Rock("a1", Player.White);
            board[7, 1] = new Knight("b1", Player.White);
            board[7, 2] = new Bishop("c1", Player.White);
            board[7, 3] = new Queen("d1", Player.White);
            board[7, 4] = new King("e1", Player.White);
            board[7, 5] = new Bishop("f1", Player.White);
            board[7, 6] = new Knight("g1", Player.White);
            board[7, 7] = new Rock("h1", Player.White);

            board[6, 0] = new Pawn("a2", Player.White);
            board[6, 1] = new Pawn("b2", Player.White);
            board[6, 2] = new Pawn("c2", Player.White);
            board[6, 3] = new Pawn("d2", Player.White);
            board[6, 4] = new Pawn("e2", Player.White);
            board[6, 5] = new Pawn("f2", Player.White);
            board[6, 6] = new Pawn("g2", Player.White);
            board[6, 7] = new Pawn("h2", Player.White);
        }
    }
}