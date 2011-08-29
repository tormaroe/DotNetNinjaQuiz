using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Domain;

namespace DotNetNinjaQuizLib.Persistance
{
    public class QuestionLevelSummary
    {
        public DifficultyLevel Difficulty { get; internal set; }
        public int Count { get; internal set; }
        public int CountWrongAnswers { get; internal set; }
        public int CountCorrectAnswers { get; internal set; }
        public int CountTimesUsed
        {
            get
            {
                return CountCorrectAnswers + CountWrongAnswers;
            }
        }
    }
}
