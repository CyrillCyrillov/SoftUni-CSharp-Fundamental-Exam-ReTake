using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int loginTryNumber = int.Parse(Console.ReadLine());

            string pattern = @"\|([A-Z]{4,})\|:#([A-Za-z]+ [A-Za-z]+)#";

            Regex validLogin = new Regex(pattern);

            for (int i = 1; i <= loginTryNumber; i++)
            {
                string nextLogin = Console.ReadLine();

                MatchCollection loginInfo = validLogin.Matches(nextLogin);

                if(loginInfo.Count > 0)
                {
                    string boss = loginInfo[0].Groups[1].ToString();
                    string title = loginInfo[0].Groups[2].ToString();

                    Console.WriteLine($"{boss}, The {title}");
                    Console.WriteLine($">> Strength: {boss.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
            
            //Console.WriteLine("Hello World!");
        }
    }
}
