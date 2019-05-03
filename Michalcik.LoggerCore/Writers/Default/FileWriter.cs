using System;
using System.IO;

namespace Michalcik.LoggerCore.Writers.Default
{
    public class FileWriter : ILogWriter
    {
        public string FilePath { get; }

        public FileWriter(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public void Write(string message)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                File.AppendAllText(FilePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}