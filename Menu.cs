using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookLab
{
    public enum rows { firstname, lastname, middlename, number, country, organization, birthday, job }
    public static class Menu
    {
        public static Dictionary<string, ConsoleKey> buttons = new Dictionary<string, ConsoleKey>
        {
            ["Home"] = ConsoleKey.Escape, ["Settings"] = ConsoleKey.P, ["Create"] = ConsoleKey.C,
            ["ShowAll"] = ConsoleKey.S, ["ShowSimple"] = ConsoleKey.Q, ["Find"] = ConsoleKey.F,
            ["Read"] = ConsoleKey.R, ["Delete"] = ConsoleKey.Delete,
            ["OrderByLName"] = ConsoleKey.D1, ["OrderByOrganization"] = ConsoleKey.D2, ["OrderByJob"] = ConsoleKey.D3,
            ["AddRow"] = ConsoleKey.A, ["EditRow"] = ConsoleKey.E, ["RemoveRow"] = ConsoleKey.X,
        };
        public const int menuPosition = 4;
        public static ConsoleColor menuColor = ConsoleColor.DarkGray;
        public static void HomeState()
        {
            Design.Draw();
            var menu = new ConsoleTables.ConsoleTable($"<{buttons["Create"].ToString()}>:Create new note", $"<{buttons["ShowAll"].ToString()}>:All notes", 
                $"<{buttons["ShowSimple"].ToString()}>:SimpleNotes", $"<{buttons["Find"].ToString()}>:Find", $"<{buttons["Settings"].ToString()}>:Settings");
            Console.ForegroundColor = menuColor;
            menu.Write();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = Design.textColor;
            Console.WriteLine();
        }
        public static void ShowAllState()
        {
            Design.Draw();
            var menu = new ConsoleTables.ConsoleTable($"<{buttons["Home"].ToString()}>:Home", $"<{buttons["Read"].ToString()}>:Read note");
            Console.ForegroundColor = menuColor;
            menu.Write();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = Design.textColor;
            Console.WriteLine();
        }
        public static void ShowSimpleState() // Same as ShowAll menu
        {
            Design.Draw();
            var menu = new ConsoleTables.ConsoleTable($"<{buttons["Home"].ToString()}>:Home", $"<{buttons["Read"].ToString()}>:Read note");
            Console.ForegroundColor = menuColor;
            menu.Write();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = Design.textColor;
            Console.WriteLine();
        }
        public static void FindState()
        {
            Design.Draw();
            var menu = new ConsoleTables.ConsoleTable($"<{buttons["Home"].ToString()}>:Home", $"<{buttons["Read"].ToString()}>:Read note",
                $"<{buttons["Find"].ToString()}>:Find");
            Console.ForegroundColor = menuColor;
            menu.Write();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = Design.textColor;
            Console.WriteLine();
        }
        public static void ReadState()
        {
            Design.Draw();
            Console.ForegroundColor = menuColor;
            var menu = new ConsoleTables.ConsoleTable($"<{buttons["Home"].ToString()}>:Home", $"<{buttons["EditRow"].ToString()}>:Edit row",
                 $"<{buttons["AddRow"].ToString()}>:Add row", $"<{buttons["RemoveRow"].ToString()}>:Remove row", $"<{buttons["Delete"].ToString()}>:Delete note");
            menu.Write();
            Console.ForegroundColor = Design.textColor;
        }
        //public static void EditState()
        //{
        //    Design.Draw();
        //    Console.ForegroundColor = menuColor;
        //    var menu = new ConsoleTables.ConsoleTable($"<{buttons["Home"].ToString()}>:Home", $"<{buttons["Edit"].ToString()}>:Edit row",
        //        $"<{buttons["Delete"].ToString()}>:Delete row");
        //    menu.Write();
        //    Console.ForegroundColor = Design.textColor;
        //}
        public static void Settings()
        {
            Design.Draw();
            var menu = new ConsoleTables.ConsoleTable($"<{buttons["Home"].ToString()}>:Home");
            Console.ForegroundColor = menuColor;
            menu.Write();
            Console.ForegroundColor = Design.textColor;
        }
    }
}
