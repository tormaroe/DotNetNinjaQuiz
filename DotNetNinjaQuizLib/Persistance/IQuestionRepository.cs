using System;
using System.Text;
using System.Linq;
using DotNetNinjaQuizLib.Domain;
using System.Collections.Generic;

namespace DotNetNinjaQuizLib.Persistance
{
    public interface IQuestionRepository : IDisposable
    {
        void AddQuestion(QuizQuestion question);
        void SaveQuestion(QuizQuestion question);
        
        QuizQuestion GetNextQuestion(GameLevel level);
        
        int CountAllQuestions();
        int CountQuestions(DifficultyLevel ofLevel);
        
        IList<QuestionLevelSummary> GetQuestionsSummary();

        IEnumerable<QuizQuestion> GetQuestions(DifficultyLevel ofLevel);
        IEnumerable<QuizQuestion> GetAllQuestions();
    }
}
