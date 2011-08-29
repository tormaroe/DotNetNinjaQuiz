using System;
using System.Windows.Input;
using DotNetNinjaQuizLib.Presenters;
using DotNetNinjaQuiz.Controls;
using System.Windows.Media;
using System.Configuration;
using System.Windows.Threading;

namespace DotNetNinjaQuiz
{
    public partial class GameWindow : System.Windows.Window, GameWindowView
    {
        private DispatcherTimer continueTimer;

        public GameWindow()
        {
            InitializeComponent();

            InitializeTitle();

            new GameWindowController(this, GameOverControl, _progressLadder);
            TriggerChangeBackgroundRequest();
        }

        private void InitializeTitle()
        {
            var overrideTitle = ConfigurationManager.AppSettings["overrideTitle"];
            Title = string.IsNullOrEmpty(overrideTitle) ? "The .Net Ninja Quiz" : overrideTitle;
            _screenTitle.Text = Title;

            _screenTitle.FontSize = Convert.ToDouble(ConfigurationManager.AppSettings["titleFontSize"]);

            continueTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 3) };        
            continueTimer.Tick += (sender, e) =>
            {
                continueTimer.Stop();
                if (_state == GUIState.DisplayingResult)
                    TriggerNewQuestion();    
            };
            
        }

        public void StoppAutoActions()
        {
            _state = GUIState.GameOver;
        }

        #region Key down event to view event
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (Keyboard.Modifiers)
            {
                case ModifierKeys.Control:
                    switch (e.Key)
                    {
                        case Key.B:
                            TriggerChangeBackgroundRequest();
                            break;
                        //case Key.N:
                        //    TriggerNewQuestion();
                        //    break;
                    }
                    break;
                case ModifierKeys.None:
                    switch (e.Key)
                    {
                        case Key.A:
                            TriggerAnswerSelected(AnswerCode.A);
                            break;
                        case Key.B:
                            TriggerAnswerSelected(AnswerCode.B);
                            break;
                        case Key.C:
                            TriggerAnswerSelected(AnswerCode.C);
                            break;
                        case Key.D:
                            TriggerAnswerSelected(AnswerCode.D);
                            break;
                        case Key.Enter:
                            TriggerCommitOrNewQuestion();
                            break;
                    }
                    break;                
            }
        }
        #endregion

        enum GUIState
        {
            NotStarted,
            QuestionReady,
            Answered,
            DisplayingResult,
            GameOver,
        }
        private GUIState _state = GUIState.NotStarted;

        /// <summary>
        /// Exists for historical reasons. Different shortcuts were used for commit and new question
        /// , but ENTER is now used for both. This method will trigger the right one...
        /// </summary>
        private void TriggerCommitOrNewQuestion()
        {
            switch (_state)
            {
                case GUIState.NotStarted: TriggerNewQuestion(); break;
                case GUIState.QuestionReady: /* do nothing */ break;
                case GUIState.Answered: TriggerAnswerCommitted(); break;
                case GUIState.DisplayingResult: TriggerNewQuestion(); break;
                case GUIState.GameOver: TriggerNewQuestion(); break;
            }
        }

        #region GameWindowView Members

        public event EventHandler NewQuestion;
        public event EventHandler<AnswerSelectedEventArgs> AnswerSelected;
        public event EventHandler AnswerCommitted;
        public event EventHandler ChangeBackgroundRequest;

        public virtual void TriggerNewQuestion()
        {
            _state = GUIState.QuestionReady;
            if (NewQuestion != null)
                NewQuestion(null, EventArgs.Empty);
        }

        private void TriggerAnswerSelected(AnswerCode answer)
        {
            _state = GUIState.Answered;
            if (AnswerSelected != null)
                AnswerSelected(null, new AnswerSelectedEventArgs { SelectedAnswer = answer });
        }

        public virtual void TriggerAnswerCommitted()
        {
            _state = GUIState.DisplayingResult;
            continueTimer.Start();
            if (AnswerCommitted != null)
                AnswerCommitted(null, EventArgs.Empty);
        }
        
        public virtual void TriggerChangeBackgroundRequest()
        {
            if (ChangeBackgroundRequest != null)
                ChangeBackgroundRequest(null, EventArgs.Empty);
        }

        public AnswerButton Button(AnswerCode answerCode)
        {
            switch (answerCode)
            {
                case AnswerCode.A:
                    return _answerAButton;
                case AnswerCode.B:
                    return _answerBButton;
                case AnswerCode.C:
                    return _answerCButton;
                case AnswerCode.D:
                    return _answerDButton;
                default:
                    throw new ApplicationException("Unknown answer code..");
            }
        }

        public QuestionBox QuestionBox
        {
            get { return _questionBox; }
        }

        public Brush BackgroundImage
        {
            set
            {
                Background = value;
            }
        }

        #endregion
    }
}
