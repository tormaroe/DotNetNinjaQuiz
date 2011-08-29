using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using DotNetNinjaQuizLib.Domain;

namespace DotNetNinjaQuiz.Controls
{
    /// <summary>
    /// Interaction logic for GameLevelSpoke.xaml
    /// </summary>
    public partial class GameLevelSpoke : UserControl
    {
        #region Properties
        
        public int LevelNumber
        {
            get
            {
                return Convert.ToInt32(_levelNumber.Text);
            }
            set
            {
                _levelNumber.Text = value.ToString();
            }
        }

        
        public string LevelDescription
        {
            get
            {
                return _levelDescription.Text;
            }
            set
            {
                _levelDescription.Text = value;
            }
        }

        private Color _levelColor;
        public Color LevelColor
        {
            get
            {
                return _levelColor;
            }
            set
            {
                _levelColor = value;
            }
        }

        private bool _completed;
        public bool Completed
        {
            get
            {
                return _completed;
            }
            set
            {
                _completed = value;

                if (_completed)
                {
                    Active = false;
                }
            }
        }

        private bool _active;
        public bool Active  
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;

                RenderVisualState();
                
            }
        }
        
        #endregion


        #region Constructors
        public GameLevelSpoke(KeyValuePair<Int32, GameLevel> levelContainer)
        {
            InitializeComponent();

            LevelNumber = levelContainer.Key;
            LevelDescription = levelContainer.Value.Label;
            LevelColor = GetSpokeColor(levelContainer);
            Active = levelContainer.Value.IsActive;
            Completed = levelContainer.Value.IsCompleted;
        }
        #endregion

        
        #region Public methods
        public void RenderVisualState()
        {
            if (_active)
            {
                _panel.Background = new SolidColorBrush(Colors.Orange);
                _completedIndicator.Foreground = new SolidColorBrush(Colors.White);
                _levelNumber.Foreground = new SolidColorBrush(Colors.White);
                _levelDescription.Foreground = new SolidColorBrush(Colors.Black);
            }
            else if (_completed)
            {
                _panel.Background = new SolidColorBrush(Colors.Transparent);
                _completedIndicator.Foreground = new SolidColorBrush(LevelColor);
                _levelNumber.Foreground = new SolidColorBrush(LevelColor);
                _levelDescription.Foreground = new SolidColorBrush(LevelColor);
            }
            else // not yet reached
            {
                _panel.Background = new SolidColorBrush(Colors.Transparent);
                _completedIndicator.Foreground = new SolidColorBrush(Colors.Transparent);
                _levelNumber.Foreground = new SolidColorBrush(LevelColor);
                _levelDescription.Foreground = new SolidColorBrush(LevelColor);
            }
        }
        #endregion

        private static Color GetSpokeColor(KeyValuePair<Int32, GameLevel> levelContainer)
        {
            return levelContainer.Key % 5 == 0 ? Colors.White : Colors.Orange;
        }
    }
}
