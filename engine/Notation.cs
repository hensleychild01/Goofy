namespace Goofy.engine
{
    public static class Notation
    {
        public static Piece ToPiece(char ascii)
        {
            return ascii switch
            {
                'P' => Piece.WhitePawn,
                'N' => Piece.WhiteKnight,
                'B' => Piece.WhiteBishop,
                'R' => Piece.WhiteRook,
                'Q' => Piece.WhiteQueen,
                'K' => Piece.WhiteKing,
                'p' => Piece.BlackPawn,
                'n' => Piece.BlackKnight,
                'b' => Piece.BlackBishop,
                'r' => Piece.BlackRook,
                'q' => Piece.BlackQueen,
                'k' => Piece.BlackKing,
                _ => throw new ArgumentException(string.Format("Piece character {0} not supported", ascii)),
            };
        }

        public static char ToChar(Piece piece)
        {
            return piece switch
            {
                Piece.None => '.',
                Piece.WhitePawn => 'P',
                Piece.WhiteKnight => 'N',
                Piece.WhiteBishop => 'B',
                Piece.WhiteRook => 'R',
                Piece.WhiteQueen => 'Q',
                Piece.WhiteKing => 'K',
                Piece.BlackPawn => 'p',
                Piece.BlackKnight => 'n',
                Piece.BlackBishop => 'b',
                Piece.BlackRook => 'r',
                Piece.BlackQueen => 'q',
                Piece.BlackKing => 'k',
                _ => throw new ArgumentException(string.Format("Piece type {0} is not a valid piece type.", (int)piece))
            };
        }

        public static byte ToSquareIndex(string squareNotation)
        {
            int file = squareNotation[0] - 97; // random ascii bs
            int rank = squareNotation[1] - 49; // more ascii bullshit
            int index = rank * 8 + file;

            if (0 <= index && index <= 63) return (byte)index;

            throw new ArgumentException(string.Format("The square notation {0} does not map to a valid square index", squareNotation));
        }
    }
}