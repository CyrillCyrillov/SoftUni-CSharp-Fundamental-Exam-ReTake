using System;
using System.Text;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string rawLine = Console.ReadLine();
                
                if (rawLine == "For Azeroth")
                {
                    break;
                }

                string[] comand = rawLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string typeComand = comand[0];

                switch (typeComand)
                {
                    case "GladiatorStance":
                        text = text.ToUpper();
                        Console.WriteLine(text);

                        break;

                    case "DefensiveStance":
                        text = text.ToLower();
                        Console.WriteLine(text);

                        break;

                    case "Dispel":
                        int index = int.Parse(comand[1]);
                        string letter = comand[2];

                        if(index >= 0 & index < text.Length)
                        {
                            text = text.Remove(index, 1);
                            text = text.Insert(index, letter);
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }

                        break;

                    case "Target":
                        if(comand[1] == "Change")
                        {
                            string substring = comand[2];
                            string stringToInsert = comand[3];

                            text = text.Replace(substring, stringToInsert);
                            Console.WriteLine(text);
                        }
                        else if (comand[1] == "Remove")
                        {
                            string substringToRemove = comand[2];

                            text = text.Replace(substringToRemove, string.Empty);
                            Console.WriteLine(text);

                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                        }
                        break;

                    default:
                        Console.WriteLine("Command doesn't exist!");

                        break;
                }
            }
            
            //Console.WriteLine("Hello World!");
        }
    }
}
