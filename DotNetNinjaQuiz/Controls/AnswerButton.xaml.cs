using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotNetNinjaQuiz.Controls
{
    public enum AnswerButtonState
    {
        Normal,
        Selected,
        WrongAnswer,
        CorrectAnswer,
    }

    /// <summary>
    /// Interaction logic for AnswerButton.xaml
    /// </summary>
    public partial class AnswerButton : UserControl
    {
        private AnswerButtonState _state;

        public string AnswerText
        {
            get
            {
                return _text.Text;
            }
            set
            {
                _text.Text = value;
            }
        }

        public AnswerButton()
        {
            InitializeComponent();

            _state = AnswerButtonState.Normal;
        }

        public AnswerButton SetState(AnswerButtonState buttonState)
        {
            _state = buttonState;

            switch (_state)
            {
                case AnswerButtonState.Normal:
                    RenderButtonState(Colors.Black);
                    break;
                case AnswerButtonState.Selected:
                    RenderButtonState(Colors.Orange);
                    break;
                case AnswerButtonState.WrongAnswer:
                    RenderButtonState(Colors.Red);
                    break;
                case AnswerButtonState.CorrectAnswer:
                    RenderButtonState(Colors.Green);
                    break;                
            }
            return this;
        }

        private void RenderButtonState(Color backgroundColor)
        {
            _button.Background = new SolidColorBrush(backgroundColor);
        }
    }
}
