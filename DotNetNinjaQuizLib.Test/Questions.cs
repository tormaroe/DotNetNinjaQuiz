using System;
using NUnit.Framework;
using DotNetNinjaQuizLib.Domain;
using DotNetNinjaQuizLib.Persistance;

namespace DotNetNinjaQuizLib.Test
{
    [TestFixture]
    public class Questions
    {
        #region fields

        private const string _dbPath = "Questions.Test.dbo";
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
        public void Counts()
        {
            Assert.AreEqual(2, _repository.CountQuestions(DifficultyLevel.Easy));
            Assert.AreEqual(2, _repository.CountQuestions(DifficultyLevel.Medium));
            Assert.AreEqual(2, _repository.CountQuestions(DifficultyLevel.Difficult));
            Assert.AreEqual(1, _repository.CountQuestions(DifficultyLevel.Unknown));
            Assert.AreEqual(7, _repository.CountAllQuestions());
        }

        [Test]
        public void GetEasyQuestion()
        {            
            GameLevel level = new GameLevel()
            {
                DifficultySelector = new DifficultyDecider_Easy()
            };

            QuizQuestion question = _repository.GetNextQuestion(level);

            Assert.AreEqual(DifficultyLevel.Easy, question.Difficulty);
            Assert.That(question.QuestionText.Equals("Question 1") 
                || question.QuestionText.Equals("Question 2"));
        }

         [Test]
        public void GetMediumQuestion()
        {            
            GameLevel level = new GameLevel()
            {
                DifficultySelector = new DifficultyDecider_Medium()
            };

            QuizQuestion question = _repository.GetNextQuestion(level);

            Assert.AreEqual(DifficultyLevel.Medium, question.Difficulty);
            Assert.That(question.QuestionText.Equals("Question 3") 
                || question.QuestionText.Equals("Question 4"));
        }

         [Test]
        public void GetDifficultQuestion()
        {            
            GameLevel level = new GameLevel()
            {
                DifficultySelector = new DifficultyDecider_Difficult()
            };

            QuizQuestion question = _repository.GetNextQuestion(level);

            Assert.AreEqual(DifficultyLevel.Difficult, question.Difficulty);
            Assert.That(question.QuestionText.Equals("Question 5") 
                || question.QuestionText.Equals("Question 6"));
        }

        #endregion
    }
}
