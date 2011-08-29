using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizManager
{
    static class ConsoleExtensions
    {
        public const int CONSOLE_WIDTH = 76;

        public static void PromptHitEnterToContinue()
        {
            ResetColors();
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        public static void SetColors(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        public static void PrintLine(string text)
        {
            Console.WriteLine(text.PadRight(CONSOLE_WIDTH, ' '));
        }

        public static void ResetColors()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;            
        }

        public static string Prompt()
        {
            ResetColors();
            Console.Write("~>");
            return Console.ReadLine();
        }
    }
}
