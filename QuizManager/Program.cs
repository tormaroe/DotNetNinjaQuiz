using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Persistance;

namespace QuizManager
{
    class Program
    {
        private CommandManager _commandManager;

        public Program()
        {
            ConsoleExtensions.SetColors(ConsoleColor.Black, ConsoleColor.Yellow);
            ConsoleExtensions.PrintLine("  .NET Ninja Quiz Manager");
            ConsoleExtensions.ResetColors();

            _commandManager = new CommandManager();
        }

        public void Run()
        {
            while (true)
            {
                _commandManager.PrintCommandMenu();

            NewPrompt:
                string userInput = ConsoleExtensions.Prompt();
                if (!_commandManager.RunCommand(userInput))
                {
                    Console.WriteLine("Command '{0}' unknown, please try again..", userInput);
                    goto NewPrompt;
                }
            }
        }

        

        #region static resources
        

        public static IQuestionRepository QuestionRepository { get; private set; }

        public static void Exit()
        {
            if (QuestionRepository != null)
            {
                QuestionRepository.Dispose();
            }

            System.Environment.Exit(-1);
        }

        #endregion

        #region static void Main
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("Usage: QuizManager path_to_questions_database_file");
                Console.ReadLine();
                return;
            }

            QuestionRepository = QuestionRepositoryFactory.CreateObjectDatabaseRespository(args[0]);

            new Program().Run();            
        }
        #endregion

    }
}
