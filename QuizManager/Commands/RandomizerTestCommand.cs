using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Persistance;
using DotNetNinjaQuizLib.Domain;

namespace QuizManager.Commands
{
    public class RandomizerTestCommand : IConsoleCommand
    {

        public RandomizerTestCommand()
        {

        }

        #region IConsoleCommand Members

        public void PrintCommandDescription(string commandKey)
        {
            this.PrintCommandDescription(commandKey, "Do some randomizing :)");
        }

        public void Run()
        {
            SampleQuestions();

            Console.WriteLine();
            Console.WriteLine("Randomizing ... ");
            Console.WriteLine();

            var randomizer = new QuestionRandomizerService();
            randomizer.ShuffleAllQuestions(Program.QuestionRepository);

            SampleQuestions();
        }

        private static void SampleQuestions()
        {
            var level = new GameLevel { DifficultySelector = new DifficultyDecider_Easy() };
            for (int i = 0; i < 15; i++)
            {
                var question = Program.QuestionRepository.GetNextQuestion(level);
                question.Usage.IncreaseCorrectAnswersCount();
                Program.QuestionRepository.SaveQuestion(question);
                Console.WriteLine(question.QuestionText);
            }
        }
        #endregion
    }
}
