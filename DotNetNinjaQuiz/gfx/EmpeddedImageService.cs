using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DotNetNinjaQuiz.gfx
{
    public class EmpeddedImageService : ImageService
    {
        private const int MAX_BACKGROUND_IMAGE_INDEX = 28;
        private int _previousBackgroundIndex;

        public ImageBrush GetNextBackgroundImage()
        {
            int nextBackgroundIndex = GetNextBackgroundIndex();

            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(
                new Uri(
                    string.Format("pack://application:,,,/gfx/bg{0}.JPG", nextBackgroundIndex)
                    ));
            return brush;
        }

        private int GetNextBackgroundIndex()
        {
            int nextIndex = -1;
            Random rnd = new Random();

            do
            {
                nextIndex = rnd.Next(1, MAX_BACKGROUND_IMAGE_INDEX + 1);

            } while (nextIndex == _previousBackgroundIndex);

            _previousBackgroundIndex = nextIndex;

            return nextIndex;
        }
    }
}
