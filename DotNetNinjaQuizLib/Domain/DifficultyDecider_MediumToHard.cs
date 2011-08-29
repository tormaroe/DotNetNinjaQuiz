using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{
    public class DifficultyDecider_MediumToHard : IDecideDifficultyForGameLevel
    {
        #region IDecideDifficultyForGameLevel Members

        public DifficultyLevel GetLevel()
        {
            return new Random().Next(2).Equals(1) ?
                DifficultyLevel.Medium :
                DifficultyLevel.Difficult;            
        }

        #endregion
    }
}
