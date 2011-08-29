using System;
using DotNetNinjaQuizLib.Presenters;
using DotNetNinjaQuiz.Controls;
using System.Windows.Media;

namespace DotNetNinjaQuiz
{
    public interface GameWindowView
    {
        event EventHandler NewQuestion;
        event EventHandler<AnswerSelectedEventArgs> AnswerSelected;
        event EventHandler AnswerCommitted;
        event EventHandler ChangeBackgroundRequest;

        AnswerButton Button(AnswerCode answerCode);
        QuestionBox QuestionBox { get; }
        Brush BackgroundImage { set; }

        void StoppAutoActions();
    }
}
