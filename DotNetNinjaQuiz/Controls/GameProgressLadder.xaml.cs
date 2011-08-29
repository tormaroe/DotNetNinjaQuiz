using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotNetNinjaQuizLib.Domain;

namespace DotNetNinjaQuiz.Controls
{
    /// <summary>
    /// Interaction logic for GameProgressLadder.xaml
    /// </summary>
    public partial class GameProgressLadder : UserControl
    {
        public GameProgressLadder()
        {
            InitializeComponent();

            PopulateSpokes();
        }

        private void PopulateSpokes()
        {
            _gameLevelStack.Children.Clear();
            var gameLevels = ServiceLocator.Game.GameLevels.Reverse();

            foreach (var item in gameLevels)
            {
                AddSpoke(item);
            }
        }

        private void AddSpoke(KeyValuePair<Int32, GameLevel> levelContainer)
        {
            var spoke = new GameLevelSpoke(levelContainer);                        
            spoke.RenderVisualState();
            
            _gameLevelStack.Children.Add(spoke);
        }

        public void AdvanceLadder()
        {
            PopulateSpokes();
        }
    }
}
