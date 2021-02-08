using System;

namespace NotebookLab
{
    /// <summary>
    /// Asking for fulscreen mode,
    /// Sets "Resolution" - console width and height.
    /// The resolution can be chosen manually before fullscreen mode accepted.
    /// Controls default console width and height via constants.
    /// Resolution and max length (note field) restrictions bypassed via Sudo const.
    /// </summary>
    public static class Initialization
    {
        private const int defaultWidth = 90;
        private const int defaultHeight = 20;
        public static int maxLength;
        public const bool sudo = false;
        public static void Start()
        {
            Console.BackgroundColor = Design.background;
            Console.ForegroundColor = Design.textColor;
            Console.Clear();
            string decision;
            while (true)
            {
                Console.Write("Enter fullscreen mode: y / n ?" + Environment.NewLine);
                decision = Console.ReadLine().ToLower();
                if (decision == "y" || decision == "yes")
                {
                    Console.Clear();
                    FullScreenMode.Fullscreen();
                    break;
                }
                else if (decision == "n" || decision == "no")
                {
                    if (!sudo)
                    {
                        if (Console.WindowWidth < defaultWidth)
                        {
                            Console.SetWindowSize(defaultWidth, Console.WindowHeight);
                        }
                        if (Console.WindowHeight < defaultHeight)
                        {
                            Console.SetWindowSize(Console.WindowWidth, defaultHeight);
                        }
                    }
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }
            maxLength = (sudo) ? int.MaxValue : Console.WindowWidth / 3 - 9;
            if (!sudo)
            {
                ForbidResize.PleaseDoNotResize();
            }
            Design.Draw();
        }
    }
}
