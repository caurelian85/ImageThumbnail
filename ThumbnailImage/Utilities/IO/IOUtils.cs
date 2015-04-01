using System.IO;
using System.Text;

namespace Utilities.IO
{
    public class IOUtils
    {
        #region Read Operations
        public byte[] ReadStream(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public byte[] ReadBinaryFile(string fileName)
        {
            using (FileStream fs = OpenFileStreamForReading(fileName))
            {
                using (var br = new BinaryReader(fs))
                {
                    using (var ms = new MemoryStream())
                    {
                        while (true)
                        {
                            byte[] buffer = br.ReadBytes(32768);
                            if (buffer == null || buffer.Length <= 0)
                                return ms.ToArray();
                            ms.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

        public string ReadFile(string fileName)
        {
            string contents;
            using (var reader = new StreamReader(fileName))
            {
                contents = reader.ReadToEnd();
                reader.Close();
            }
            return contents;
        }

        public string ReadFile(string fileName, Encoding enc)
        {
            string contents;
            using (FileStream fs = OpenFileStreamForReading(fileName))
            {
                using (var reader = new StreamReader(fs, enc))
                {
                    contents = reader.ReadToEnd();
                    reader.Close();
                }
            }
            return contents;
        }
        #endregion

        #region Write Operation
        public void WriteFile(string fileName, string contents)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(contents);
                writer.Close();
            }
        }

        public void WriteFile(string fileName, string contents, Encoding enc)
        {
            using (FileStream fs = OpenFileStreamForWriting(fileName))
            {
                using (var writer = new StreamWriter(fs, enc))
                {
                    writer.Write(contents);
                    writer.Close();
                }
            }
        }

        public void WriteBinaryFile(string fileName, byte[] contents)
        {
            using (FileStream fs = OpenFileStreamForWriting(fileName))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write(contents);
                    bw.Close();
                }
            }
        }
        #endregion

        #region File Activities
        public FileStream OpenFileStreamForReading(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public FileStream OpenFileStreamForWriting(string path)
        {
            return new FileStream(path, FileMode.Create, FileAccess.Write);
        }

        public void FileMove(string sourceFileName, string destFileName)
        {
            FileMove(sourceFileName, destFileName, true);
        }

        public void FileMove(string sourceFileName, string destFileName, bool overwrite)
        {
            if (!overwrite)
            {
                File.Move(sourceFileName, destFileName);
            }
            else
            {
                File.Copy(sourceFileName, destFileName, true);
                File.Delete(sourceFileName);
            }
        }
        #endregion
    }
}
