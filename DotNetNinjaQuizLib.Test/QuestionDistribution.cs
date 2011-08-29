using System;
using NUnit.Framework;
using DotNetNinjaQuizLib.Domain;
using DotNetNinjaQuizLib.Persistance;

namespace DotNetNinjaQuizLib.Test
{
    [TestFixture]
    public class QuestionDistribution
    {
        
        #region fields

        private const string _dbPath = "QuestionDistribution.Test.dbo";
        private IQuestionRepository _repository;

        #endregion

        #region TestFixtureSetUp

        [TestFixtureSetUp]
        public void SetUpDatabase()
        {
            _repository = QuestionRepositoryFactory.CreateObjectDatabaseRespository(_dbPath);            

            _repository.AddQuestion(new QuizQuestion()
                {
                    QuestionText = "Question 1",
                    CorrectAnswer = "Correct answer",
                    WrongAnswer1 = "Wrong answer",
                    WrongAnswer2 = "Wrong answer",
                    WrongAnswer3 = "Wrong answer",
                    Difficulty = DifficultyLevel.Easy,
                });
            _repository.AddQuestion(new QuizQuestion()
                {
                    QuestionText = "Question 2",
                    CorrectAnswer = "Correct answer",
                    WrongAnswer1 = "Wrong answer",
                    WrongAnswer2 = "Wrong answer",
                    WrongAnswer3 = "Wrong answer",
                    Difficulty = DifficultyLevel.Easy,
                });
            _repository.AddQuestion(new QuizQuestion()
                {
                    QuestionText = "Question 3",
                    CorrectAnswer = "Correct answer",
                    WrongAnswer1 = "Wrong answer",
                    WrongAnswer2 = "Wrong answer",
                    WrongAnswer3 = "Wrong answer",
                    Difficulty = DifficultyLevel.Medium,
                });
            _repository.AddQuestion(new QuizQuestion()
                {
                    QuestionText = "Question 4",
                    CorrectAnswer = "Correct answer",
                    WrongAnswer1 = "Wrong answer",
                    WrongAnswer2 = "Wrong answer",
                    WrongAnswer3 = "Wrong answer",
                    Difficulty = DifficultyLevel.Medium,
                });
            _repository.AddQuestion(new QuizQuestion()
                {
                    QuestionText = "Question 5",
                    CorrectAnswer = "Correct answer",
                    WrongAnswer1 = "Wrong answer",
                    WrongAnswer2 = "Wrong answer",
                    WrongAnswer3 = "Wrong answer",
                    Difficulty = DifficultyLevel.Difficult,
                });
            _repository.AddQuestion(new QuizQuestion()
                {
                    QuestionText = "Question 6",
                    CorrectAnswer = "Correct answer",
                    WrongAnswer1 = "Wrong answer",
                    WrongAnswer2 = "Wrong answer",
                    WrongAnswer3 = "Wrong answer",
                    Difficulty = DifficultyLevel.Difficult,
                });
            _repository.AddQuestion(new QuizQuestion()
                {
                    QuestionText = "Question 7",
                    CorrectAnswer = "Correct answer",
                    WrongAnswer1 = "Wrong answer",
                    WrongAnswer2 = "Wrong answer",
                    WrongAnswer3 = "Wrong answer",
                    Difficulty = DifficultyLevel.Unknown,
                });
        }

        #endregion

        #region TestFixtureTearDown

        [TestFixtureTearDown]
        public void DeleteDatabase()
        {
            _repository.Dispose();
            QuestionRepositoryFactory.DropObjectDatabase(_dbPath);
        }

        #endregion

        #region Tests

        [Test]
        public void Test()
        {
            GameLevel level = new GameLevel()
            {
                DifficultySelector = new DifficultyDecider_Easy()
            };

            QuizQuestion question = _repository.GetNextQuestion(level);
            string question1text = question.QuestionText;

            question.Usage.IncreaseCorrectAnswersCount();

            Assert.AreEqual(1, question.Usage.NumberOfTimesCorrect);
            Assert.AreEqual(0, question.Usage.NumberOfTimesWrong);
            Assert.AreEqual(1, question.Usage.NumberOfTimesUsed);

            _repository.SaveQuestion(question);

            question = _repository.GetNextQuestion(level);

            Assert.AreNotEqual(question1text, question.QuestionText);
        }

        #endregion
    }
}
