using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Domain;

namespace QuizImporter
{
    public static class QuizQuestionHelperExtensions
    {
        public static void Print(this QuizQuestion q)
        {
            Console.WriteLine("Q: {0}", q.QuestionText);
            Console.WriteLine("\tA1: {0}", q.CorrectAnswer);
            Console.WriteLine("\tA2: {0}", q.WrongAnswer1);
            Console.WriteLine("\tA3: {0}", q.WrongAnswer2);
            Console.WriteLine("\tA4: {0}", q.WrongAnswer3);
            Console.WriteLine("\tDifficulty: {0}", q.Difficulty);
        }
    }
}
