using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookLab
{
    public enum MachineState : byte { Home, Create, ShowAll, ShowSimple, Find, Read, Delete, Settings }

    /// Click <see url="https://drive.google.com/open?id=1xSOK_-HppwMp_bVj5FiU9oZd2-wiigMi">here</see> to See the scheme.
    public class Notebook
    {
        public static List<Note> notes = new List<Note>();
        public static MachineState currentState;
        public static int readId;
        static void Main(string[] args)
        {
            Initialization.Start();
            //Console.WriteLine("\nLet's create your first note! Press <Enter> and have fun...\n");
            //while (Console.ReadKey().Key != ConsoleKey.Enter) { ClearCurrentConsoleLine(0); }
            currentState = MachineState.Home;
            while (true)
            {
                switch (currentState)
                {
                    case MachineState.Home:
                        {
                            currentState = MachineState.Home;
                            Menu.HomeState();
                            Console.WriteLine($"You have {notes.Count} notes.\n");
                            MachineState state = currentState;
                            while (true)
                            {
                                ConsoleKey key = Console.ReadKey().Key;
                                ClearCurrentConsoleLine(0);
                                if (key == ConsoleKey.C)
                                {
                                    goto case MachineState.Create;
                                }
                                if (key == ConsoleKey.S)
                                {
                                    goto case MachineState.ShowAll;
                                }
                                if (key == ConsoleKey.Q)
                                {
                                    goto case MachineState.ShowSimple;
                                }
                                if (key == ConsoleKey.F)
                                {
                                    goto case MachineState.Find;
                                }
                                if (key == ConsoleKey.P)
                                {
                                    goto case MachineState.Settings;
                                }
                            }
                        }
                    case MachineState.Create:
                        {
                            currentState = MachineState.Create;
                            CreateNewNote(out int id);
                            readId = id;
                            goto case MachineState.Read;
                        }
                    case MachineState.ShowAll:
                        {
                            currentState = MachineState.ShowAll;
                            ShowAllNotes();
                            while (true)
                            {
                                ConsoleKey key = Console.ReadKey().Key;
                                if (key == ConsoleKey.Escape)
                                {
                                    goto case MachineState.Home;
                                }
                                else if (key == ConsoleKey.R)
                                {
                                    if (notes.Count == 0)
                                    {
                                        Console.Beep();
                                        goto case MachineState.Home;
                                    }
                                    while (true)
                                    {
                                        Console.Write("Enter note id: ");
                                        if (int.TryParse(Console.ReadLine(), out readId))
                                        {
                                            if (readId >= 0 && readId < notes.Count)
                                            {
                                                goto case MachineState.Read;
                                            }
                                            else
                                            {
                                                Console.Beep();
                                                ClearCurrentConsoleLine(1);
                                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.Beep();
                                            ClearCurrentConsoleLine(1);
                                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    case MachineState.ShowSimple:
                        {
                            currentState = MachineState.ShowSimple;
                            ShowSimplifiedNotes();
                            while (true)
                            {
                                ConsoleKey key = Console.ReadKey().Key;
                                if (key == ConsoleKey.Escape)
                                {
                                    goto case MachineState.Home;
                                }
                                if (key == ConsoleKey.R)
                                {
                                    ClearCurrentConsoleLine(1);
                                    ClearCurrentConsoleLine(0);
                                    if (notes.Count == 0)
                                    {
                                        Console.Beep();
                                        goto case MachineState.Home;
                                    }
                                    Console.Write("Enter id: ");
                                    while (true)
                                    {
                                        while (!int.TryParse(Console.ReadLine(), out readId))
                                        {
                                            ClearCurrentConsoleLine(1);
                                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                                            Console.Write("Enter id: ");
                                            Console.Beep();
                                        }
                                        if (readId >= 0 && readId < notes.Count)
                                        {
                                            goto case MachineState.Read;
                                        }
                                        Console.Beep();
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        ClearCurrentConsoleLine(0);
                                        Console.Write("Enter id: ");
                                    }
                                }
                            }
                        }
                    case MachineState.Find:
                        {
                            currentState = MachineState.Find;
                            Menu.FindState();
                            Find(out int results);
                            while (true)
                            {
                                ConsoleKey key = Console.ReadKey().Key;
                                if (key == ConsoleKey.Escape)
                                {
                                    goto case MachineState.Home;
                                }
                                if (key == ConsoleKey.F)
                                {
                                    goto case MachineState.Find;
                                }
                                if (key == ConsoleKey.R)
                                {
                                    if (results == 0)
                                    {
                                        Console.Beep();
                                        goto case MachineState.Home;
                                    }
                                    ClearCurrentConsoleLine(1);
                                    ClearCurrentConsoleLine(0);
                                    Console.Write("Enter id: ");
                                    while (true)
                                    {
                                        while (!int.TryParse(Console.ReadLine(), out readId))
                                        {
                                            ClearCurrentConsoleLine(1);
                                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                                            Console.Write("Enter id: ");
                                            Console.Beep();
                                        }
                                        if (readId >= 0 && readId < notes.Count)
                                        {
                                            goto case MachineState.Read;
                                        }
                                        Console.Beep();
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        ClearCurrentConsoleLine(0);
                                        Console.Write("Enter id: ");
                                    }
                                }
                            }
                        }
                    case MachineState.Read:
                        {
                            ReadMarker:
                            currentState = MachineState.Read;
                            ReadNote(notes[readId]);
                            while (true)
                            {
                                ConsoleKey key = Console.ReadKey().Key;
                                ClearCurrentConsoleLine(0);
                                if (key == ConsoleKey.Escape)
                                {
                                    goto case MachineState.Home;
                                }
                                if (key == ConsoleKey.E) // Edit row
                                {
                                    Console.Write("Enter row name:");
                                    string row = Console.ReadLine();
                                    string rowCopy = row.Trim().ToLower();
                                    var array = rowCopy.Split(' ');
                                    rowCopy = string.Join("", array);
                                    switch (rowCopy)
                                    {
                                        case ("firstname"):
                                            notes[readId].FirstName = Console.ReadLine();
                                            goto ReadMarker;
                                        case ("lastname"):
                                            notes[readId].LastName = Console.ReadLine();
                                            goto ReadMarker;
                                        case ("middlename"):
                                            notes[readId].MiddleName = Console.ReadLine();
                                            goto ReadMarker;
                                        case ("number"):
                                            notes[readId].Number = Console.ReadLine();
                                            goto ReadMarker;
                                        case ("country"):
                                            notes[readId].Country = Console.ReadLine();
                                            goto ReadMarker;
                                        case ("organization"):
                                            notes[readId].Organization = Console.ReadLine();
                                            goto ReadMarker;
                                        case ("job"):
                                            notes[readId].Job = Console.ReadLine();
                                            goto ReadMarker;
                                        case ("birthdate"):
                                            notes[readId].Birthday = Console.ReadLine();
                                            goto ReadMarker;
                                        default:
                                            break;
                                    }
                                    switch (row)
                                    {
                                        default:
                                            try
                                            {
                                                notes[readId].additionalNotes[row] = Console.ReadLine();
                                            }
                                            catch (KeyNotFoundException)
                                            {
                                            }
                                            catch (NullReferenceException)
                                            { }
                                            goto ReadMarker;
                                    }
                                }
                                if (key == ConsoleKey.A) // Add row
                                {
                                    Console.Write("Enter row name: ");
                                    string row = Console.ReadLine();
                                    try
                                    {
                                        notes[readId].additionalNotes.Add(row, "");
                                    }
                                    catch (NullReferenceException)
                                    {
                                    }
                                }
                                if (key == ConsoleKey.X) // Remove row
                                {
                                    Console.Write("Enter row name:");
                                    string row = Console.ReadLine().Trim().ToLower();
                                    if (Note.lockedFields.Contains(row))
                                    {
                                        Design.Draw();
                                        Console.Beep();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write("You can't remove default rows");
                                        Console.ForegroundColor = Design.textColor;
                                        System.Threading.Thread.Sleep(2000);
                                        goto case MachineState.Read;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            notes[readId].additionalNotes.Remove(row);
                                        }
                                        catch (Exception)
                                        {
                                            Console.Beep();
                                        }
                                        goto case MachineState.Read;
                                    }
                                }
                                if (key == ConsoleKey.D) // Delete note
                                {
                                    goto case MachineState.Delete;
                                }
                                break;
                            }
                            goto case MachineState.Read;
                        }
                    
                    case MachineState.Delete:
                        {
                            currentState = MachineState.Delete;
                            DeleteNote(readId, out bool deleted);
                            if (deleted)
                            {
                                goto case MachineState.Home;
                            }
                            goto case MachineState.Read;
                        }

                    case MachineState.Settings:
                        {
                            currentState = MachineState.Settings;
                            Menu.Settings();
                            Console.WriteLine("Nothing here...");
                            while (true)
                            {
                                if (Console.ReadKey().Key == ConsoleKey.Escape)
                                {
                                    goto case MachineState.Home;
                                }
                                ClearCurrentConsoleLine(0);
                            }
                        }
                    default:
                        Console.Clear();
                        goto case MachineState.Home;
                }
            }
        }
        public static void ClearCurrentConsoleLine(int n)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - n);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public static void CreateNewNote(out int id)
        {
            Design.Draw();
            Console.WriteLine();
            notes.Add(new Note());
            id = notes.Count - 1;
            Console.Write("Name: ");
            notes[id].FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            notes[id].LastName = Console.ReadLine();
            Console.Write("Number: ");
            notes[id].Number = Console.ReadLine();
            Console.Write("Country: ");
            notes[id].Country = Console.ReadLine();
        }
        public static void DeleteNote(int id, out bool deleted)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            while (true)
            {
                Console.WriteLine("Are You Sure: y / n ? ");
                string choise = Console.ReadLine().Trim().ToLower();
                if (choise == "y" || choise == "yes")
                {
                    Console.ForegroundColor = Design.textColor;
                    notes.RemoveAt(id);
                    for (int i = id; i < notes.Count; i++)
                    {
                        notes[i].id = i;
                    }
                    deleted = true;
                    break;
                }
                else if (choise == "n" || choise == "no")
                {
                    Console.ForegroundColor = Design.textColor;
                    ClearCurrentConsoleLine(0);
                    ClearCurrentConsoleLine(1);
                    deleted = false;
                    break;
                }
            }
        }
        public static void ReadNote(Note note)
        {
            Menu.ReadState();
            var table = new ConsoleTables.ConsoleTable("1","Last name",note.LastName);
            table.AddRow("2", "First Name", note.FirstName)
                 .AddRow("3", "Middle Name", note.MiddleName)
                 .AddRow("4", "Number", note.Number)
                 .AddRow("5", "Country", note.Country)
                 .AddRow("6", "Birth Date", note.Birthday)
                 .AddRow("7", "Organization", note.Organization)
                 .AddRow("8", "Job", note.Job);
            int i = 9;
            try
            {
                foreach (KeyValuePair<string, string> entry in note.additionalNotes)
                {
                    table.AddRow(i, entry.Key, entry.Value);
                    i++;
                }
            }
            catch (NullReferenceException)
            {
            }
            finally { table.Write(); }
        }
        public static void ShowAllNotes()
        {
            Menu.ShowAllState();
            for (int i = 0; i < notes.Count; i++)
            {
                var table = new ConsoleTables.ConsoleTable("Id", $"{notes[i].id}");
                table.AddRow("Last name", notes[i].LastName)
                     .AddRow("First name", notes[i].FirstName)
                     .AddRow("Middle name", notes[i].MiddleName)
                     .AddRow("Number", notes[i].Number)
                     .AddRow("Country", notes[i].Country)
                     .AddRow("Birth Date", notes[i].Birthday)
                     .AddRow("Organization", notes[i].Organization)
                     .AddRow("Job", notes[i].Job);
                try
                {
                    foreach (KeyValuePair<string, string> entry in notes[i].additionalNotes)
                    {
                        table.AddRow(entry.Key, entry.Value);
                    }
                }
                catch (Exception)
                {
                }
                finally { table.Write(); }
            }
        }
        public static void ShowSimplifiedNotes()
        {
            Menu.ShowSimpleState();
            for (int i = 0; i < notes.Count; i++)
            {
                var table = new ConsoleTables.ConsoleTable("Id", $"{notes[i].id}");
                table.AddRow("Lastname", notes[i].LastName)
                     .AddRow("FirstName", notes[i].FirstName)
                     .AddRow("Number", notes[i].Number);
                table.Write();
            }
        }
        public static void Find(out int results)
        {
            Console.Write("Enter Last name keyword: ");
            string keyword = Console.ReadLine();
            results = 0;
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].LastName.ToLower().Contains(keyword))
                {
                    results++;
                    var table = new ConsoleTables.ConsoleTable("Id", $"{notes[i].id}");
                    table.AddRow("Lastname", notes[i].LastName)
                         .AddRow("FirstName", notes[i].FirstName)
                         .AddRow("Number", notes[i].Number);
                    table.Write();
                }
            }
            if (results == 0)
            {
                Console.WriteLine("Sorry, nothing found...");
            }
            else
            {
                Console.WriteLine("Notes: " + results);
            }
        }

    }
}

