using Chess.engine;

namespace Chess
{
    public static class UI
    {
        public static void Run()
        {
            Board board = new(Board.StartingFEN);
            PrintBoard(board);

            bool running = true;
            while (running) 
            {
                string? cmd = Console.ReadLine();
                if (cmd == null || cmd == "") break;
                board.Play(new Move(cmd));
                PrintBoard(board);
            }
        }

        private static void PrintBoard(Board board)
        {
            Console.WriteLine();
            for (int rank = 7; rank >= 0; rank--)
            {
                Console.Write(string.Format("{0}|", rank + 1));
                for (int file = 0; file < 8; file++)
                {
                    Piece piece = board[rank, file];
                    PrintPiece(piece);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  ----------------");
            Console.WriteLine("  A B C D E F G H");
        }

        private static void PrintPiece(Piece piece)
        {
            Console.Write(Notation.ToChar(piece));
            Console.Write(' ');
        }
    }
}