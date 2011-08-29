using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizManager.Commands
{
    static class IConsoleCommandExtensions
    {        
        public static void PrintCommandDescription(
            this IConsoleCommand command, 
            string commandKey, 
            string shortDescription)
        {
            Console.WriteLine("\t{0}:\t{1}", commandKey, shortDescription);
        }
    }
}
