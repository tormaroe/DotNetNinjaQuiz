using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetNinjaQuizLib.Domain;
using System.Configuration;
using System.IO;

namespace DotNetNinjaQuiz
{
    static class ServiceLocator
    {
        public static GameController Game { get; private set; }
        
        public static gfx.ImageService Images { get; private set; }
        
        public static gfx.SoundService Sound{ get; private set; }

        static ServiceLocator()
        {
            CreateNewGame();
            CreateImageService();
            Sound = new gfx.SoundService();
        }

        private static void CreateImageService()
        {
            Images = gfx.OverrideImageService.UseOverride 
                ? new gfx.OverrideImageService() 
                : new gfx.EmpeddedImageService() as gfx.ImageService;            
        }

        public static void CreateNewGame()
        {
            if (Game != null)
                Game.Dispose();

            var dbFile = new FileInfo(ConfigurationSettings.AppSettings["questionsDatabase"]);
            Game = new GameController(dbFile.FullName);

            OverrideLevelsInfo overrideLevelsInfo = new OverrideLevelsInfoImplementor();
            if (overrideLevelsInfo.ShouldUseOverrides)
                overrideLevelsInfo.PerformOverride(Game.GameLevels);
        }
    }
}
