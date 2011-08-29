using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Configuration;

namespace DotNetNinjaQuiz.gfx
{
    public interface ImageService
    {
        ImageBrush GetNextBackgroundImage();
    }
}
