using System;

namespace Michalcik.LoggerCore.Writers.Default
{
    public class ConsoleWriter : ILogWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}