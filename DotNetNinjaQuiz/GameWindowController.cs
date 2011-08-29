using System;
using DotNetNinjaQuizLib.Presenters;
using DotNetNinjaQuiz.Controls;
using DotNetNinjaQuizLib.Domain;

namespace DotNetNinjaQuiz
{
    public class GameWindowController
    {
        private GameWindowView _gameView;
        private GameOverDialog _gameOverView;
        private GameProgressLadder _gameProgressView;
        private bool _answerCommitted;
        private AnswerCode _answerGivenByUser = AnswerCode.AnswerNotGiven;

        public GameWindowController(GameWindowView view, GameOverDialog gameOverView, GameProgressLadder gameProgressView)
        {
            _gameProgressView = gameProgressView;
            _gameOverView = gameOverView;
            _gameView = view;
            RandomizeQuestions();
            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            _gameView.NewQuestion += _view_NewQuestion;
            _gameView.AnswerSelected += _view_AnswerSelected;
            _gameView.AnswerCommitted += _view_AnswerCommitted;
            _gameView.ChangeBackgroundRequest += _view_ChangeBackgroundRequest;
        }

        void _view_ChangeBackgroundRequest(object sender, EventArgs e)
        {
            SetANewBackground();   
        }

        void _view_AnswerCommitted(object sender, EventArgs e)
        {
            if (!ReadyToCommitAnswer)
                return;

            _answerCommitted = true;
            DisplayAnswerResult(ServiceLocator.Game.CommitAnswer(_answerGivenByUser));
            HandleGameOver();
        }

        private void DisplayAnswerResult(CommitAnswerResult commitAnswerResult)
        {
            if (commitAnswerResult.WasAnswerCorrect)
            {
                _gameView.Button(commitAnswerResult.UserAnswer).SetState(AnswerButtonState.CorrectAnswer);
                //ServiceLocator.Sound.PlayEffect(gfx.SoundEffect.QuestionCommitted);
                ServiceLocator.Sound.PlayEffect(gfx.SoundEffect.Applause);
            }
            else
            {
                _gameView.Button(commitAnswerResult.UserAnswer).SetState(AnswerButtonState.WrongAnswer);
                _gameView.Button(commitAnswerResult.CorrectAnswer).SetState(AnswerButtonState.CorrectAnswer);
            }
        }

        private void HandleGameOver()
        {
            if (!ServiceLocator.Game.GameOver)
                return;

            _gameView.StoppAutoActions();

            if (ServiceLocator.Game.CurrentLevel.DifficultySelector.GetLevel() == DifficultyLevel.Easy)
                ServiceLocator.Sound.PlayEffect(gfx.SoundEffect.Laughter);
            else
                ServiceLocator.Sound.PlayEffect(gfx.SoundEffect.Applause);

            var reachedLevel = ServiceLocator.Game.HighestCompletedLevel;
            if (reachedLevel != null)
                _gameOverView.Show(reachedLevel.Label);
            else
                _gameOverView.ShowZeroCorrect();
        }

        private bool ReadyToCommitAnswer
        {
            get
            {
                return ServiceLocator.Game.CurrentQuestion != null
                    && _answerGivenByUser != AnswerCode.AnswerNotGiven
                    && !_answerCommitted;
            }
        }
        private void ResetAllAnswers()
        {
            _gameView.Button(AnswerCode.A).SetState(AnswerButtonState.Normal);
            _gameView.Button(AnswerCode.B).SetState(AnswerButtonState.Normal);
            _gameView.Button(AnswerCode.C).SetState(AnswerButtonState.Normal);
            _gameView.Button(AnswerCode.D).SetState(AnswerButtonState.Normal);
        }

        void _view_AnswerSelected(object sender, AnswerSelectedEventArgs e)
        {         
            ResetAllAnswers();
            _answerGivenByUser = e.SelectedAnswer;
            _gameView.Button(e.SelectedAnswer).SetState(AnswerButtonState.Selected);
            //ServiceLocator.Sound.PlayEffect(gfx.SoundEffect.ButtonPress);
        }

        void _view_NewQuestion(object sender, EventArgs e)
        {
            if (ServiceLocator.Game.GameOver)
                CreateBrandNewGame();

            if (NotReadyForNewQuestion)
                return;

            _gameProgressView.AdvanceLadder();
            _answerGivenByUser = AnswerCode.AnswerNotGiven;
            SetQuestionAndAnswersTexts(ServiceLocator.Game.GetNewQuestion(ServiceLocator.Game.CurrentLevel));
            //ServiceLocator.Sound.PlayEffect(gfx.SoundEffect.NewQuestion);
            _answerCommitted = false;
        }

        private bool NotReadyForNewQuestion
        {
            get
            {
                return (ServiceLocator.Game.CurrentQuestion != null
                                && _answerGivenByUser == AnswerCode.AnswerNotGiven)
                                || ServiceLocator.Game.GameOver;
            }
        }
        private void SetQuestionAndAnswersTexts(QuestionPresenter questionPresenter)
        {
            _gameView.QuestionBox.QuestionText = questionPresenter.QuestionText;
            _gameView.Button(AnswerCode.A)
                .SetState(AnswerButtonState.Normal)
                .AnswerText = String.Format("A: {0}", questionPresenter.AnswerA);
            _gameView.Button(AnswerCode.B)
                .SetState(AnswerButtonState.Normal)
                .AnswerText = String.Format("B: {0}", questionPresenter.AnswerB);
            _gameView.Button(AnswerCode.C)
                .SetState(AnswerButtonState.Normal)
                .AnswerText = String.Format("C: {0}", questionPresenter.AnswerC);
            _gameView.Button(AnswerCode.D)
                .SetState(AnswerButtonState.Normal)
                .AnswerText = String.Format("D: {0}", questionPresenter.AnswerD);
        }

        private void CreateBrandNewGame()
        {
            _gameOverView.Hide();
            RandomizeQuestions();
            ServiceLocator.CreateNewGame();
            SetANewBackground();
            _answerGivenByUser = AnswerCode.AnswerNotGiven;
            _answerCommitted = false;
        }

        private void RandomizeQuestions()
        {
            
            var randomizer = new QuestionRandomizerService();
            randomizer.ShuffleAllQuestions(ServiceLocator.Game.QuestionRepository);
        }

        private void SetANewBackground()
        {
            _gameView.BackgroundImage = ServiceLocator.Images.GetNextBackgroundImage();
        }
    }
}
