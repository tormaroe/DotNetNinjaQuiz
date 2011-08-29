using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Persistance;
using System.Collections;

namespace DotNetNinjaQuizLib.Domain
{
    public class QuestionRandomizerService
    {
        public void ShuffleAllQuestions(IQuestionRepository repoitory)
        {
            var allQuestions = repoitory.GetAllQuestions();
            ShuffleQuestions(allQuestions);

            foreach (var question in allQuestions)
            {
                repoitory.SaveQuestion(question);
            }
        }

        private void ShuffleQuestions(IEnumerable<QuizQuestion> questions)
        {

            foreach (var question in questions)
                question.ShuffleIndex = NextRandom();            
        }

        private static int NextRandom()
        {
            return BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
        }
    }
}
