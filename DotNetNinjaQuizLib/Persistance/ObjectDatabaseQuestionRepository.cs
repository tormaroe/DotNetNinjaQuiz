using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Domain;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace DotNetNinjaQuizLib.Persistance
{
    public class ObjectDatabaseQuestionRepository : IQuestionRepository
    {
        #region IQuestionRepository Members


        public IList<QuestionLevelSummary> GetQuestionsSummary()
        {
            var query = from QuizQuestion qq in _db
                        group qq by qq.Difficulty into f
                        select new QuestionLevelSummary() 
                        { 
                            Count = f.Count(), 
                            Difficulty = f.Key,
                            CountCorrectAnswers = f.Sum(qq => qq.Usage.NumberOfTimesCorrect),
                            CountWrongAnswers = f.Sum(qq => qq.Usage.NumberOfTimesWrong),
                        };
            return query.ToList<QuestionLevelSummary>();           
        }


        public void AddQuestion(QuizQuestion question)
        {
            _db.Store(question);
        }

        public void SaveQuestion(QuizQuestion question)
        {
            _db.Store(question);
        }

        public QuizQuestion GetNextQuestion(GameLevel level)
        {
            DifficultyLevel difficulty = level.DifficultySelector.GetLevel();

            var query = from QuizQuestion qq in _db
                        where qq.Difficulty == difficulty
                        orderby qq.Usage.NumberOfTimesUsed,
                                qq.ShuffleIndex // randomizer
                        select qq;

            return query.First();
        }

        public IEnumerable<QuizQuestion> GetQuestions(DifficultyLevel ofLevel)
        {
            return from QuizQuestion q in _db
                   where q.Difficulty == ofLevel
                   select q;
        }

        public IEnumerable<QuizQuestion> GetAllQuestions()
        {
            return from QuizQuestion q in _db
                   select q;
        }

        public int CountQuestions(DifficultyLevel ofLevel)
        {
            return (from QuizQuestion q in _db
                    where q.Difficulty == ofLevel
                    select q).Count();
        }

        public int CountAllQuestions()
        {            
            return (from QuizQuestion q in _db 
                    select q).Count();
        }        

        #endregion

        #region Fields and constructor

        private IObjectContainer _db;

        public ObjectDatabaseQuestionRepository(IObjectContainer db)
        {
            _db = db;
        }

        #endregion

        #region Dispose

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            _isDisposed = true;

            if (disposing)
            {
                if (_db != null)
                {
                    _db.Close();
                }
            }
        }

        #endregion

    }
}
