using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizManager.Commands
{
    class QuitProgramCommand : IConsoleCommand
    {
        public void PrintCommandDescription(string commandKey)
        {
            this.PrintCommandDescription(commandKey, "Quit this program");
        }

        public void Run()
        {
            Program.Exit();
        }
    }
}
