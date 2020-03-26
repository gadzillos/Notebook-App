using System;

namespace NotebookLab
{

    public class Design
    {
        public static ConsoleColor textColor = ConsoleColor.White;
        public static ConsoleColor Backround = ConsoleColor.Black;
        // TODO: Add themes if buisness logic is ready
        // Design could be a struct but class provides further improvements 
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
