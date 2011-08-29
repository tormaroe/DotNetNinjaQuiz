using System;
using DotNetNinjaQuizLib.Domain;
using System.Collections.Generic;

namespace DotNetNinjaQuizLib.Factories
{
    /// <summary>
    /// This is basically a hard-coded configuration class,
    /// deciding the steps / difficulty levels in the game.
    /// </summary>
    internal static class GameLevelFactory
    {
        internal static SortedList<int, GameLevel> CreateDefaultGameLevels()
        {
            SortedList<int, GameLevel> list = new SortedList<int, GameLevel>();

            #region levels 1 to 5
            list.Add(
                1, new GameLevel()
            {
                Label = "Newbie",
                DifficultySelector = new DifficultyDecider_Easy(),
            });
            list.Add(
                2, new GameLevel()
                {
                    Label = "Script Kiddie",
                    DifficultySelector = new DifficultyDecider_Easy(),
                });
            list.Add(
                3, new GameLevel()
                {
                    Label = "Code Monkey",
                    DifficultySelector = new DifficultyDecider_EasyToMedium(),
                });
            list.Add(
                4, new GameLevel()
                {
                    Label = "Trainee",
                    DifficultySelector = new DifficultyDecider_EasyToMedium(),
                });
            list.Add(
                5, new GameLevel()
                {
                    Label = "Junior",
                    DifficultySelector = new DifficultyDecider_EasyToMedium(),
                });
            #endregion
            #region levels 6 to 10
            list.Add(
                6, new GameLevel()
                {
                    Label = "Apprentice I",
                    DifficultySelector = new DifficultyDecider_Medium(),
                });
            list.Add(
                7, new GameLevel()
                {
                    Label = "Apprentice II",
                    DifficultySelector = new DifficultyDecider_Medium(),
                });
            list.Add(
                8, new GameLevel()
                {
                    Label = "Journeyman I",
                    DifficultySelector = new DifficultyDecider_Medium(),
                });
            list.Add(
                9, new GameLevel()
                {
                    Label = "Journeyman II",
                    DifficultySelector = new DifficultyDecider_MediumToHard(),
                });
            list.Add(
                10, new GameLevel()
                {
                    Label = "Professional",
                    DifficultySelector = new DifficultyDecider_MediumToHard(),
                });
            #endregion
            #region levels 11 to 15
            list.Add(
                11, new GameLevel()
                {
                    Label = "Mentor",
                    DifficultySelector = new DifficultyDecider_MediumToHard(),
                });
            list.Add(
                12, new GameLevel()
                {
                    Label = "Syntax Monk",
                    DifficultySelector = new DifficultyDecider_MediumToHard(),
                });
            list.Add(
                13, new GameLevel()
                {
                    Label = "Black Belt",
                    DifficultySelector = new DifficultyDecider_Difficult(),
                });
            list.Add(
                14, new GameLevel()
                {
                    Label = ".Net Guru",
                    DifficultySelector = new DifficultyDecider_Difficult(),
                });
            list.Add(
                15, new GameLevel()
                {
                    Label = ".NET NINJA",
                    DifficultySelector = new DifficultyDecider_Difficult(),
                });
            #endregion

            return list;
        }
    }
}
