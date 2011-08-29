using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace DotNetNinjaQuiz.Controls
{
    public partial class GameOverDialog : UserControl
    {
        private string _line1Override;
        private string _zeroCorrectLine1Override;
        private string _zeroCorrectLine2Override;
        private string _zeroCorrectLine3Override;

        public GameOverDialog()
        {
            InitializeComponent();
            LoadOverrides();
        }

        private void LoadOverrides()
        {
            _line1Override = ConfigurationManager.AppSettings["overrideResultLine1"];
            _zeroCorrectLine1Override = ConfigurationManager.AppSettings["overrideZeroCorrectLine1"];
            _zeroCorrectLine2Override = ConfigurationManager.AppSettings["overrideZeroCorrectLine2"];
            _zeroCorrectLine3Override = ConfigurationManager.AppSettings["overrideZeroCorrectLine3"];
        }

        public void Show(string levelName)
        {
            if (string.IsNullOrEmpty(_line1Override))
                Show(getYouAreAText(levelName),
                    levelName,
                    "!!!");
            else
                Show(_line1Override,
                    levelName,
                    "!!!");

        }

        public void ShowZeroCorrect()
        {
            if (string.IsNullOrEmpty(_zeroCorrectLine1Override))
                Show("Are you sure you", 
                    "are a developer at all", 
                    "???");
            else
                Show(_zeroCorrectLine1Override, 
                    _zeroCorrectLine2Override, 
                    _zeroCorrectLine3Override);
        }

        private void Show(string line1, string line2, string line3)
        {
            _youAreA.Text = line1;
            _levelName.Text = line2;
            _line3.Text = line3;
            Visibility = Visibility.Visible;
        }

        private string getYouAreAText(string levelName)
        {
            return StartsWithVowel(levelName) ?
                "You are an" :
                "You are a";
        }

        private bool StartsWithVowel(string text)
        {
            char[] vowels = new[] { 'A', 'E', 'I', 'O', 'U', 'Y' };
            for (int i = 0; i < vowels.Length; i++)
            {
                if (text[0] == vowels[i])
                    return true;
            }
            return false;
        }

        public void Hide()
        {
            Visibility = Visibility.Collapsed;
        }  
    }
}
