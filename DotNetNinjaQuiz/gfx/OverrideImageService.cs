using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Configuration;

namespace DotNetNinjaQuiz.gfx
{
    public class OverrideImageService : ImageService
    {
        public static string OverrideImage
        {
            get
            {
                return ConfigurationManager.AppSettings["overrideBackgroundImage"];
            }
        }

        public static bool UseOverride
        {
            get
            {
                return !string.IsNullOrEmpty(OverrideImage);
            }
        }

        private ImageBrush _backgroundImage;

        public OverrideImageService()
        {
            _backgroundImage = new ImageBrush 
            {
                ImageSource = new BitmapImage(new Uri(OverrideImage))
            };
        }

        public ImageBrush GetNextBackgroundImage()
        {
            return _backgroundImage;
        }
    }
}
