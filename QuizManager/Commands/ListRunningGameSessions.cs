using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizManager.Commands
{
    class ListRunningGameSessions : IConsoleCommand
    {

        public void PrintCommandDescription(string commandKey)
        {
            this.PrintCommandDescription(commandKey, "List running game sessions");
        }

        public void Run()
        {
            ConsoleExtensions.PrintLine("NOT YET IMPLEMENTED");
        }

    }
}
