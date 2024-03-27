using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GarageManager.UserInterface
{
    internal class ConsoleUI : IUI
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
        
        public string GetInput()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string input = Console.ReadLine()!;
            Console.ResetColor();
            return input;
        }
    }
}
