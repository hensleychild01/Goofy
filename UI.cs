using Goofy.engine;

namespace Goofy
{
    public static class UI
    {
        public static void Run()
        {
            Board board = new(Board.StartingFEN);

            bool running = true;
            while (running)
            {
                Print(board);
                string? cmd = Console.ReadLine();
                if (cmd == null || cmd == "") break;

                string[] moves = cmd.Split(' ');
                foreach (string move in moves)
                    ApplyMove(board, move);
            }
        }

        private static void ApplyMove(Board board, string input) 
        {
            Move move = new(input);
            board.Play(move);
        }

        private static void Print(Board board)
        {
            Console.WriteLine();
            for (int rank = 7; rank >= 0; rank--)
            {
                Console.Write(string.Format("{0}|", rank + 1));
                for (int file = 0; file < 8; file++)
                {
                    Piece piece = board[rank, file];
                    Print(piece);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  ----------------");
            Console.WriteLine("  A B C D E F G H");
        }

        private static void Print(Piece piece)
        {
            Console.Write(Notation.ToChar(piece));
            Console.Write(' ');
        }
    }
}