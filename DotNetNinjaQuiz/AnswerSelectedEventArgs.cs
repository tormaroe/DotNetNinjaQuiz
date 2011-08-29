using System;
using DotNetNinjaQuizLib.Presenters;

namespace DotNetNinjaQuiz
{
    public class AnswerSelectedEventArgs : EventArgs
    {
        public AnswerCode SelectedAnswer { get; set; }
    }
}
