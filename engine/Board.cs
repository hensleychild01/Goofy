namespace Chess.engine
{

    public enum Piece
    {
        None = 0,
        WhitePawn = 1,
        WhiteKnight = 2,
        WhiteBishop = 3,
        WhiteRook = 4,
        WhiteQueen = 5,
        WhiteKing = 6,
        BlackPawn = 7,
        BlackKnight = 8,
        BlackBishop = 9,
        BlackRook = 10,
        BlackQueen = 11,
        BlackKing = 12
    }

    public struct Move
    {
        public byte ToIndex;
        public byte FromIndex;
        public Piece Promotion;

        public Move(byte fromIndex, byte toIndex, Piece promotion)
        {
            ToIndex = toIndex;
            FromIndex = fromIndex;
            Promotion = promotion;
        }

        public Move(string uciMoveNotation)
        {
            string fromSquare = uciMoveNotation[..2];
            string toSquare = uciMoveNotation[2..4];

            FromIndex = Notation.ToSquareIndex(fromSquare);
            ToIndex = Notation.ToSquareIndex(toSquare);
            Promotion = (uciMoveNotation.Length == 5) ? Notation.ToPiece(uciMoveNotation[4]) : Piece.None;
        }
    }

    public class Board
    {
        public const string StartingFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        Piece[] state = new Piece[64];

        public Board(string fen)
        {
            int rank = 7;
            int file = 0;

            foreach (char symbol in fen.Split(' ')[0])
            {

                // if (rank > 7 || file > 7) throw new ArgumentException(string.Format("FEN string '{0}' is not valid.", fen.Split(' ')[0]));

                if (symbol == '/')
                {
                    rank--;
                    file = 0;
                    continue;
                }

                if (char.IsDigit(symbol))
                    for (int i = 0; i < char.GetNumericValue(symbol); i++)
                    {
                        // Console.WriteLine(string.Format("rank: {0}, file: {1}, index: {2}", rank, file, rank * 8 + file));
                        state[rank * 8 + file] = Piece.None;
                        file++;
                    }
                else 
                {
                    state[rank * 8 + file] = Notation.ToPiece(symbol);
                    file++;
                }
            }
        }

        public Piece this[int rank, int file]
        {
            get => state[rank * 8 + file];
            set => state[rank * 8 + file] = value;
        }

        public Piece this[int index]
        {
            get => state[index];
            set => state[index] = value;
        }
        public void Play(Move move)
        {
            Piece movingPiece = state[move.FromIndex];
            if (move.Promotion != Piece.None)
                movingPiece = move.Promotion;

            state[move.ToIndex] = movingPiece;

            state[move.FromIndex] = Piece.None;
        }
    }

}