using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GarageManager.Helpers
{
    public static class Util
    {
        public static string AskForInput(string prompt)
        {
            string answer = "";

            while (true)
            {
                Console.WriteLine($"{prompt}");
                answer = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                else
                {
                    return answer;
                }
            }
        }

        public static uint AskForNumber(string prompt)
        {
            while (true)
            {
                string input = AskForInput(prompt);

                if (uint.TryParse(input, out uint number))
                    return number;
            }
        }

        public static void PrintWithColour(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
