using System;
using System.Collections.Generic;

namespace NotebookLab
{

    public class Design
    {
        public static ConsoleColor textColor = ConsoleColor.White;
        public static ConsoleColor background = ConsoleColor.Black;
        // TODO: Add themes if buisness logic is ready
        // Design could be a struct but class provides further improvements 
        public static List<ConsoleColor> colors = new List<ConsoleColor>()
        {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.White
        };
        public static void Draw()
        {
            Console.Clear();
            Console.Write(new string('#', Console.WindowWidth));
            Console.WriteLine();
            Console.Write(new string('~', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string('#', Console.WindowWidth));
            Console.WriteLine();
        }

    }
}
