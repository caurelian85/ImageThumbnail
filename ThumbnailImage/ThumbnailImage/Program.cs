using System;

namespace ThumbnailImage
{
    class Program
    {
        private const string ImageSourcePath="Do not forgot to set the path!";
        private const string ImageResultPath = "Do not forgot to set the path!";

        private static void Main(string[] args)
        {
            var thumb  = ImageUtils.CreateThumbnailImage(ImageSourcePath, System.Drawing.Imaging.ImageFormat.Png, 156, 156);
            IOUtils.WriteBinaryFile(ImageResultPath, thumb);
            Console.ReadKey();
        }
    }
}
