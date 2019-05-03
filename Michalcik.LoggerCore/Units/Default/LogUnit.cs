using Michalcik.LoggerCore.Formatters;
using Michalcik.LoggerCore.Writers;
using System;
using System.Collections.Generic;

namespace Michalcik.LoggerCore.Units.Default
{
    public class LogUnit : ILogUnit
    {
        private ILogFormatter formatter;
        private IEnumerable<ILogWriter> writers;

        public LogUnit(ILogFormatter formatter, IEnumerable<ILogWriter> writers)
        {
            this.formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            this.writers = writers ?? throw new ArgumentNullException(nameof(writers));
        }

        public void LogMessage(LogLevel level, DateTime time, string message, object source)
        {
            string formattedMessage = formatter.FormatMessage(level, time, message, source);

            foreach (ILogWriter writer in writers)
                writer.Write(formattedMessage);
        }

        public void LogException(LogLevel level, DateTime time, Exception exception, object source)
        {
            LogMessage(level, time, formatter.FormatException(exception), source);
        }
    }
}