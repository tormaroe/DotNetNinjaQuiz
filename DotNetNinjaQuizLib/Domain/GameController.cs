using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Factories;
using DotNetNinjaQuizLib.Persistance;
using DotNetNinjaQuizLib.Presenters;

namespace DotNetNinjaQuizLib.Domain
{
    public interface OverrideLevelsInfo
    {
        Dictionary<int, string> LevelNames { get; }
        bool ShouldUseOverrides { get; }
        void PerformOverride(SortedList<int, GameLevel> levels);
    }

    public class GameController : IDisposable
    {
        #region Fields
        private SortedList<int, GameLevel> _gameLevels;
        private IQuestionRepository _repository;
        private int _activeLevelKey;
        #endregion

        #region Properties
        public bool GameOver { get; private set; }
        
        public SortedList<int, GameLevel> GameLevels
        {
            get
            {
                return _gameLevels;
            }
        }

        public IQuestionRepository QuestionRepository 
        { 
            get 
            { 
                return _repository; 
            } 
        }


        public GameLevel CurrentLevel
        {
            get
            {
                return this.GameLevels[_activeLevelKey];
            }
        }

        public GameLevel HighestCompletedLevel
        {
            get // man, this was ugly! :(
            {
                const int outOfBounds = -1;
                var levelInfo = new { GameLevel = new GameLevel(), sortKey = outOfBounds };                

                foreach (var anotherLevel in GameLevels)
                {
                    if (anotherLevel.Value.IsCompleted
                        && anotherLevel.Key > levelInfo.sortKey)
                    {
                        levelInfo = new { GameLevel = anotherLevel.Value, sortKey = anotherLevel.Key };
                    }
                }

                if (levelInfo.sortKey == outOfBounds)
                    return null;
                return levelInfo.GameLevel;
            }
        }
        public QuestionPresenter CurrentQuestion
        {
            get;
            private set;
        }
        #endregion

        #region Public methods        

        public QuestionPresenter GetNewQuestion(GameLevel level)
        {
            CurrentQuestion = new QuestionPresenter(_repository.GetNextQuestion(level));
            return CurrentQuestion;
        }

        public CommitAnswerResult CommitAnswer(AnswerCode answer)
        {
            CommitAnswerResult answerResult = CurrentQuestion.CommitAnswer(answer, this);

            if (answerResult.WasAnswerCorrect)
            {
                var nextLevelKey = _activeLevelKey + 1;
                if (_gameLevels.Count >= nextLevelKey)
                {
                    SetActiveLevel(nextLevelKey);
                }
                else
                {
                    GameOver = true;
                    this.CurrentLevel.IsCompleted = true;
                    //.NET Ninja reached!!! Congratulation
                }
            }
            else
            {
                GameOver = true;
                //stop the game
            }

            return answerResult;
        }
        #endregion

        #region Constructors
        public GameController(string questionsDatabasePath)
        {
            _repository = QuestionRepositoryFactory.CreateObjectDatabaseRespository(questionsDatabasePath); 
            
            _gameLevels = GameLevelFactory.CreateDefaultGameLevels();
            SetActiveLevel(1);
        }
        #endregion

        #region Private methods
        private void SetActiveLevel(int levelKey)
        {
            _activeLevelKey = levelKey;

            //TODO: make sure key exists...
            // When player reaches the top of the stack, this must be handled somewhere...

            _gameLevels[levelKey].IsActive = true;

            int previousLevelkey = levelKey - 1;

            if (previousLevelkey > 0)
            {
                _gameLevels[previousLevelkey].IsCompleted = true;
            }
        }
        #endregion

        #region IDisposable Members

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
                if (_repository != null)
                {
                    _repository.Dispose();
                }
            }
        }

        #endregion
    }
}
