using System;
using Utilities;

namespace ThumbnailImage
{
    class Program
    {
        private const string ImageSourcePath = "D:\\a.jpg";
        private const string ImageResultPath = "ResultPicture.png";

        private static void Main(string[] args)
        {
            var thumb = Util.Image.CreateThumbnailImage(ImageSourcePath, System.Drawing.Imaging.ImageFormat.Png, 156, 156);
            Util.File.WriteBinaryFile(ImageResultPath, thumb);
            Console.ReadKey();
        }
    }
}
