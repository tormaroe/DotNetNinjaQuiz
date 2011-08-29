using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{
    public class DifficultyDecider_Easy : IDecideDifficultyForGameLevel
    {
        #region IDecideDifficultyForGameLevel Members

        public DifficultyLevel GetLevel()
        {
            return DifficultyLevel.Easy;
        }

        #endregion
    }
}
