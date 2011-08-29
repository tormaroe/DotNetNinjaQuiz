using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{
    public interface IDecideDifficultyForGameLevel
    {
        DifficultyLevel GetLevel();
    }
}
