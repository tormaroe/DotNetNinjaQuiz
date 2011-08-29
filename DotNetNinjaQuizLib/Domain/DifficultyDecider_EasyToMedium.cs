using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{
    public class DifficultyDecider_EasyToMedium : IDecideDifficultyForGameLevel
    {
        #region IDecideDifficultyForGameLevel Members

        public DifficultyLevel GetLevel()
        {
            if (new Random().Next(2).Equals(1))
                return DifficultyLevel.Easy;
            else
                return DifficultyLevel.Medium;            
        }

        #endregion
    }
}
