using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{
    public class QuizSession
    {
        public QuizPlayer Player { get; set; }
        public QuizProgress Progress { get; set; }
    }
}
