using System;
using System.Collections.Generic;

namespace NotebookLab
{
    public class Note
    {
        public const int requierdFields = 4;
        public int id;
        public int fieldsNumber;
        private string firstName;
        private string lastName;
        private string middleName;
        private string number;
        private string country;
        private string organization;
        private string birthday;
        private string job;
        public Dictionary<string, string> additionalNotes = new Dictionary<string, string>();
        public static List<string> lockedFields = new List<string>() { "first name", "last name", "middle name",
        "number", "country", "organization", "birth date", "job"};
        public Note()
        {
            this.id = (Notebook.notes.Count == 0) ? 0 : Notebook.notes.Count;
            this.fieldsNumber = requierdFields;
        }
        
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                value = value.Trim();
                if (value == "" || value.Length > Initialization.maxLength || value.Contains(" "))
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Please enter last name: ");
                    Console.ForegroundColor = Design.textColor;
                    Console.Beep();
                    this.LastName = Console.ReadLine();
                }
                else
                {
                    value = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
                    this.lastName = value;
                }
            }
        }
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                value = value.Trim();
                if (value == "" || value.Length > Initialization.maxLength)
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Please enter country: ");
                    Console.ForegroundColor = Design.textColor;
                    Console.Beep();
                    this.Country = Console.ReadLine();
                }
                else
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    value = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
                    Console.Write("Country: " + value + "\n");
                    this.country = value;
                }
            }
        }
        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                value = value.Trim();
                if (value.Contains(" ") || value.Contains("-") || value == "" || value == "0" || !long.TryParse(value, out _))
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Please enter correct number: ");
                    Console.ForegroundColor = Design.textColor;
                    Console.Beep();
                    this.Number = Console.ReadLine();
                }
                else if (long.TryParse(value, out _))
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("Number: " + value + "\n");
                    this.number = value;
                }
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                value = value.Trim();
                if (value == "" || value.Length > Initialization.maxLength || value.Contains(" "))
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Please enter name: ");
                    Console.ForegroundColor = Design.textColor;
                    Console.Beep();
                    this.FirstName = Console.ReadLine();
                }
                else
                {
                    if (value.ToLower() == "pepe")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    value = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
                    Console.Write("Name: " + value + "\n");
                    this.firstName = value;
                }
            }
        }
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                value = value.Trim();
                if (value.Length > Initialization.maxLength || value.Contains(" "))
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Please enter middle name: ");
                    Console.ForegroundColor = Design.textColor;
                    Console.Beep();
                    this.MiddleName = Console.ReadLine();
                }
                else
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    value = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
                    Console.Write("Middle name: " + value + "\n");
                    this.middleName = value;
                }
            }
        }
        public string Organization
        {
            get
            {
                return this.organization;
            }
            set
            {
                value = value.Trim();
                if (value.Length > Initialization.maxLength)
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("Please enter shorter organization name: ");
                    Console.Beep();
                    this.Organization = Console.ReadLine();
                }
                else
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    value = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
                    Console.Write("Organization: " + value + "\n");
                    this.organization = value;
                }
            }
        }
        public string Job
        {
            get
            {
                return this.job;
            }
            set
            {
                value = value.Trim();
                if (value.Length > Initialization.maxLength)
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("Please enter shorter job name: ");
                    Console.Beep();
                    this.Job = Console.ReadLine();
                }
                else
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write("Job: " + value + "\n");
                    this.job = value;
                }
            }
        }
        public string Birthday // few bugs may occur
        {
            get
            {
                return this.birthday;
            }
            set // Laaaaazy checking 
            {
                value = value.Trim();
                string[] temp = value.Split('.');
                int dd, mm, yy;
                bool wrongDate = false;
                if (temp.Length != 3)
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Please enter birth date <dd.mm.yy>: ");
                    Console.ForegroundColor = Design.textColor;
                    Console.Beep();
                    this.Birthday = Console.ReadLine();
                }
                else if (value.Length != 8 || !int.TryParse(temp[0], out dd) || !int.TryParse(temp[1], out mm) || !int.TryParse(temp[2], out yy))
                {
                    wrongDate = true;
                }
                else if (dd < 1 || dd > 31 || mm < 1 || mm > 12)
                {
                    wrongDate = true;
                }
                else if (mm == 02 && dd > 29)
                {
                    wrongDate = true;
                }
                if (wrongDate == true)
                {
                    Notebook.ClearCurrentConsoleLine(1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Please enter birth date <dd.mm.yy>: ");
                    Console.ForegroundColor = Design.textColor;
                    Console.Beep();
                    this.Birthday = Console.ReadLine();
                }
                else
                {
                    this.birthday = value;
                }
            }
        }

    }
}
