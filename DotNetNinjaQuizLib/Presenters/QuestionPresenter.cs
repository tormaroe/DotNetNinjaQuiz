using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Domain;

namespace DotNetNinjaQuizLib.Presenters
{

    public class QuestionPresenter
    {
        #region fields
        private QuizQuestion _question;

        private Dictionary<AnswerCode, string> _randomizedAnswerDictionary;
        
        private AnswerCode _correctAnswerCode;
        #endregion

        #region properties
        public string QuestionText
        {
            get
            {
                return _question.QuestionText;
            }
        }

        public string AnswerA
        {
            get
            {
                return GetAnswerByAnswerCode(AnswerCode.A);
            }
        }
        public string AnswerB
        {
            get
            {
                return GetAnswerByAnswerCode(AnswerCode.B);
            }
        }
        public string AnswerC
        {
            get
            {
                return GetAnswerByAnswerCode(AnswerCode.C);
            }
        }
        public string AnswerD
        {
            get
            {
                return GetAnswerByAnswerCode(AnswerCode.D);
            }
        }
        #endregion

        #region constructor
        public QuestionPresenter(QuizQuestion question)
        {
            _question = question;

            CreateRandomizedAnswerDictionary();
        }
        #endregion

        #region public methods

        internal CommitAnswerResult CommitAnswer(AnswerCode answer, GameController game)
        {
            CommitAnswerResult result = new CommitAnswerResult(answer, _correctAnswerCode);

            if (result.WasAnswerCorrect)
            {
                _question.Usage.IncreaseCorrectAnswersCount();
            }
            else
            {
                _question.Usage.IncreaseWrongAnswersCount();                
            }

            game.QuestionRepository.SaveQuestion(_question);

            return result;
        }

        #endregion

        #region private methods

        private void CreateRandomizedAnswerDictionary()
        {
            _randomizedAnswerDictionary = new Dictionary<AnswerCode, string>(4);

            List<AnswerCode> orderedAnswerCodeList = new List<AnswerCode>();
            orderedAnswerCodeList.Add(AnswerCode.A);
            orderedAnswerCodeList.Add(AnswerCode.B);
            orderedAnswerCodeList.Add(AnswerCode.C);
            orderedAnswerCodeList.Add(AnswerCode.D);

            List<AnswerCode> randomAnswerCodeList = new List<AnswerCode>(4);
            Random rand = new Random();
            int randomIndex;
            while (orderedAnswerCodeList.Count > 0)
            {
                randomIndex = rand.Next(0, orderedAnswerCodeList.Count);
                randomAnswerCodeList.Add(orderedAnswerCodeList[randomIndex]);
                orderedAnswerCodeList.RemoveAt(randomIndex);
            }

            _correctAnswerCode = randomAnswerCodeList[0];
            _randomizedAnswerDictionary.Add(randomAnswerCodeList[0], _question.CorrectAnswer);
            _randomizedAnswerDictionary.Add(randomAnswerCodeList[1], _question.WrongAnswer1);
            _randomizedAnswerDictionary.Add(randomAnswerCodeList[2], _question.WrongAnswer2);
            _randomizedAnswerDictionary.Add(randomAnswerCodeList[3], _question.WrongAnswer3);
        }

        private string GetAnswerByAnswerCode(AnswerCode answerCode)
        {
            return _randomizedAnswerDictionary[answerCode];
        }

        #endregion
    }
}
