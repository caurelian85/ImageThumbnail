using Utilities.DesignPattern;
using Utilities.Image;
using Utilities.IO;

namespace Utilities
{
    public static class Util
    {
        #region Utilities

        public static ImageUtils Image
        {
            get { return Singleton<ImageUtils>.Instance; }
        }

        public static IOUtils File
        {
            get { return Singleton<IOUtils>.Instance; }
        }
        #endregion
    }
}
