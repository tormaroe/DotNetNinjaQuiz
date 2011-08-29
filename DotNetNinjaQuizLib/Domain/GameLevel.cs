using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNinjaQuizLib.Domain
{
    public class GameLevel
    {
        /// <summary>
        /// The identifier of the level. Can be the amount of dollar you will win
        /// on that level.
        /// </summary>
        public string Label { get; set; }

        public IDecideDifficultyForGameLevel DifficultySelector { get; set; }

        public bool IsActive { get; set; }

        public bool IsCompleted { get; set; }
    }
}
