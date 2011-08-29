using System;
using QuizManager.Commands;
using System.Collections.Generic;

namespace QuizManager
{
    class CommandManager
    {
        #region fields
        Dictionary<string, IConsoleCommand> _commandDictionary;
        #endregion

        #region Initialization
        public CommandManager()
        {
            _commandDictionary = new Dictionary<string, IConsoleCommand>();

            AddCommand("1", new ListRunningGameSessions());
            AddCommand("2", new GetQuestionsSummaryCommand());
            AddCommand("3", new RandomizerTestCommand());
            AddCommand("4", new QuitProgramCommand());
        }

        private void AddCommand(string commandKey,  IConsoleCommand command)
        {
            _commandDictionary.Add(
                commandKey,
                command);
        }
        #endregion

        #region Print menu
        public void PrintCommandMenu()
        {
            Console.WriteLine();
            foreach (var commandBag in _commandDictionary)
            {
                commandBag.Value.PrintCommandDescription(commandBag.Key);
            }
            Console.WriteLine();
        }
        #endregion

        #region Run command
        public bool RunCommand(string commandKey)
        {
            if (_commandDictionary.ContainsKey(commandKey))
            {
                try
                {
                    _commandDictionary[commandKey].Run();
                    ConsoleExtensions.PromptHitEnterToContinue();
                }
                catch (Exception ex)
                {
                    ConsoleExtensions.SetColors(ConsoleColor.White, ConsoleColor.Red);
                    ConsoleExtensions.PrintLine(ex.Message);
                    ConsoleExtensions.PromptHitEnterToContinue();
                }
                return true;

            }
            return false;
        }
        #endregion
    }
}
