using System;
using System.Linq;
using System.Collections.Generic;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> spellBook = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string typeComand = comand[0].ToUpper();

                if(typeComand == "END")
                {
                    break;
                }

                string heroName = comand[1];
                

                switch (typeComand)
                {
                    case "ENROLL":
                        if(spellBook.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} is already enrolled.");
                        }
                        else
                        {
                            spellBook.Add(heroName, new List<string>()); //{ string.Empty });
                        }

                        break;

                    case "LEARN":
                        if(comand.Length >= 3)
                        {
                            string spellName = comand[2];
                            if (comand.Length > 3)
                            {
                                for (int i = 3; i < comand.Length; i++)
                                {
                                    spellName = spellName + " " + comand[i];
                                }
                            }

                            if (spellBook.ContainsKey(heroName))
                            {
                                if (spellBook[heroName].Contains(spellName))
                                {
                                    Console.WriteLine($"{heroName} has already learnt {spellName}.");
                                }
                                else
                                {
                                    spellBook[heroName].Add(spellName);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} doesn't exist.");
                            }
                        }
                        

                        break;

                    case "UNLEARN":
                        if(comand.Length >= 3)
                        {
                            string spellName = comand[2];
                            if (comand.Length > 3)
                            {
                                for (int i = 3; i < comand.Length; i++)
                                {
                                    spellName = spellName + " " + comand[i];
                                }
                            }

                            if (spellBook.ContainsKey(heroName))
                            {
                                if (spellBook[heroName].Contains(spellName))
                                {
                                    spellBook[heroName].Remove(spellName);
                                }
                                else
                                {
                                    Console.WriteLine($"{heroName} doesn't know {spellName}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} doesn't exist.");
                            }
                        }
                        

                        break;

                    default:
                        break;
                }
            }

            if(spellBook.Count > 0)
            {
                Console.WriteLine("Heroes:");
                foreach (var element in spellBook.OrderBy(x => x.Key).ThenBy(y => y.Value.Count))
                {
                    Console.Write($"== {element.Key}: ");
                    Console.WriteLine(string.Join(", ", element.Value));
                }
            }
            
            
            //Console.WriteLine("Hello World!");
        }
    }
}
