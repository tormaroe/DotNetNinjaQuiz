using System;
using DotNetNinjaQuizLib.Domain;

namespace QuizImporter
{
    internal static class DifficultyLevelHelperExtentions
    {
        internal static DifficultyLevel ConvertToDifficultyLevel(this string s)
        {
            switch (s)
            {
                case "1": return DifficultyLevel.Easy;
                case "2": return DifficultyLevel.Medium;
                case "3": return DifficultyLevel.Difficult;
                default: return DifficultyLevel.Unknown;
            }
        }
    }
}
