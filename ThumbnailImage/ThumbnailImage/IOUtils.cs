using System.IO;

namespace ThumbnailImage
{
    public class IOUtils
    {
        public static void WriteBinaryFile(string fileName, byte[] contents)
        {
            using (FileStream fs = OpenFileStreamForWriting(fileName))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(contents);
                    bw.Close();
                }
            }
        }

        public static FileStream OpenFileStreamForWriting(string path)
        {
            return new FileStream(path, FileMode.Create, FileAccess.Write);
        }
    }
}
