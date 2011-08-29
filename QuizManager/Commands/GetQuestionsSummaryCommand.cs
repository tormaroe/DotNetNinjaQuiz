using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Persistance;

namespace QuizManager.Commands
{
    class GetQuestionsSummaryCommand : IConsoleCommand
    {
        public void PrintCommandDescription(string commandKey)
        {
            this.PrintCommandDescription(commandKey, "Get questions summary");
        }

        public void Run()
        {
            PrintLine("Difficulty", "Count", "Times used", "Times correct", "Times wrong");

            var questionsSummary = Program.QuestionRepository.GetQuestionsSummary();

            foreach (var summary in questionsSummary)
            {
                PrintLine(
                    summary.Difficulty.ToString(),
                    summary.Count.ToString(),
                    summary.CountTimesUsed.ToString(),
                    summary.CountCorrectAnswers.ToString(),
                    summary.CountWrongAnswers.ToString());
            }
        }

        private void PrintLine(
            string value1,
            string value2,
            string value3,
            string value4,
            string value5)
        {
            Console.WriteLine(
                    "{0}{1}{2}{3}{4}",
                    value1.PadRight(15, ' '),
                    value2.PadLeft(15, ' '),
                    value3.PadLeft(15, ' '),
                    value4.PadLeft(15, ' '),
                    value5.PadLeft(15, ' ')
                    );
        }
    }
}
