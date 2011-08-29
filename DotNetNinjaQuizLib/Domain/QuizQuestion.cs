using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{

    public class QuizQuestion
    {
        public string QuestionText { get; set; }

        public string CorrectAnswer { get; set; }
        
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        
        public DifficultyLevel Difficulty { get; set; }

        public UsageInfo Usage { get; set; }

        public int ShuffleIndex { get; set; }

        public QuizQuestion()
        {
            Difficulty = DifficultyLevel.Unknown;
            Usage = new UsageInfo();
        }
    }
}
