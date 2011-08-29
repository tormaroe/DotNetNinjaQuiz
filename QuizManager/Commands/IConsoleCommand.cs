using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizManager.Commands
{
    interface IConsoleCommand
    {
        void PrintCommandDescription(string commandKey);
        void Run();
    }
}
