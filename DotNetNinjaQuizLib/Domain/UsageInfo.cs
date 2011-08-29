using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{
    public class UsageInfo
    {
        public int NumberOfTimesCorrect { get; private set; }
        public int NumberOfTimesWrong { get; private set; }

        public int NumberOfTimesUsed
        {
            get
            {
                return NumberOfTimesCorrect + NumberOfTimesWrong;
            }
        }
        
        public UsageInfo()
        {
            NumberOfTimesCorrect = 0;
            NumberOfTimesWrong = 0;
        }

        public void IncreaseCorrectAnswersCount()
        {
            NumberOfTimesCorrect++;
        }

        public void IncreaseWrongAnswersCount()
        {
            NumberOfTimesWrong++;
        }
    }
}
