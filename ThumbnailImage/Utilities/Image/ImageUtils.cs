using System.IO;

namespace Utilities.Image
{
    public class ImageUtils
    {
        public byte[] CreateThumbnailImage(string imgFilePath, System.Drawing.Imaging.ImageFormat thumbFormat, int thumbWidth, int thumbHeight)
        {
            using (var srcImage = System.Drawing.Image.FromFile(imgFilePath))
            {
                using (var thmbImage = srcImage.GetThumbnailImage(thumbWidth, thumbHeight, () => true, System.IntPtr.Zero))
                {
                    using (var thmbStream = new MemoryStream())
                    {
                        thmbImage.Save(thmbStream, thumbFormat);
                        return thmbStream.ToArray();
                    }
                }
            }
        }

        public byte[] CreateThumbnailImage(byte[] img, System.Drawing.Imaging.ImageFormat thumbFormat, int thumbWidth, int thumbHeight)
        {
            using (var imgStream = new MemoryStream(img))
            {
                using (var srcImage = System.Drawing.Image.FromStream(imgStream))
                {
                    using (var thmbImage = srcImage.GetThumbnailImage(thumbWidth, thumbHeight, () => true, System.IntPtr.Zero))
                    {
                        using (var thmbStream = new MemoryStream())
                        {
                            thmbImage.Save(thmbStream, thumbFormat);
                            return thmbStream.ToArray();
                        }
                    }
                }
            }
        }
    }
}
