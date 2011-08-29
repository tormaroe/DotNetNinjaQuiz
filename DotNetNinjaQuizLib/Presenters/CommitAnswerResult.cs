using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Presenters
{
    public class CommitAnswerResult
    {

        #region Properties
        public AnswerCode CorrectAnswer { get; internal set; }

        public AnswerCode UserAnswer { get; internal set; }
        public bool WasAnswerCorrect 
        {
            get { return UserAnswer == CorrectAnswer; }
        }
        #endregion
        #region Constructors
        public CommitAnswerResult(AnswerCode userAnswered, AnswerCode correctAnswer)
        {
            UserAnswer = userAnswered;
            CorrectAnswer = correctAnswer;
        }
        #endregion
    }
}
