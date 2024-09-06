using System;
using System.Diagnostics;

using Goofy.engine;

namespace Goofy
{
    class Program
    {
        public static void Main(string[] args)
        {
            UI.Run();

            // while (true)
            // {
            //     string? command = Console.ReadLine();
            //     if (command == null || cmd == "") break;
            //     switch (command.Split(' ')[0])
            //     {
            //         case "uci":
            //             Console.WriteLine("uciok");
            //             break;
            //         case "isready": 
            //             Console.WriteLine("readyok");
            //             break;
            //         case "go":
            //             Console.WriteLine("bestmove e7e5");
            //             break;
            //         default:
            //             Debugger.Launch();
            //             break;
            //     }
            // }
        }
    }
}