using System;
using System.Collections.Generic;
using System.Configuration;
using DotNetNinjaQuizLib.Domain;

namespace DotNetNinjaQuiz
{    
    public class OverrideLevelsInfoImplementor : OverrideLevelsInfo
    {
        public Dictionary<int, string> LevelNames { get; private set; }

        public bool ShouldUseOverrides { get; private set; }

        public OverrideLevelsInfoImplementor()
        {
            ShouldUseOverrides = Convert.ToBoolean(ConfigurationManager.AppSettings["overrideLevelLabels"]);

            if (ShouldUseOverrides)
                LoadOverrides();

        }

        private void LoadOverrides()
        {
            LevelNames = new Dictionary<int, string>();
            LevelNames.Add(1, Get("overrideLevel1"));
            LevelNames.Add(2, Get("overrideLevel2"));
            LevelNames.Add(3, Get("overrideLevel3"));
            LevelNames.Add(4, Get("overrideLevel4"));
            LevelNames.Add(5, Get("overrideLevel5"));
            LevelNames.Add(6, Get("overrideLevel6"));
            LevelNames.Add(7, Get("overrideLevel7"));
            LevelNames.Add(8, Get("overrideLevel8"));
            LevelNames.Add(9, Get("overrideLevel9"));
            LevelNames.Add(10, Get("overrideLevel10"));
            LevelNames.Add(11, Get("overrideLevel11"));
            LevelNames.Add(12, Get("overrideLevel12"));
            LevelNames.Add(13, Get("overrideLevel13"));
            LevelNames.Add(14, Get("overrideLevel14"));
            LevelNames.Add(15, Get("overrideLevel15"));
        }

        private string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public void PerformOverride(SortedList<int, GameLevel> levels)
        {
            foreach (var item in levels)
            {
                item.Value.Label = LevelNames[item.Key];
            }
        }

    }
}
