using System;

namespace Michalcik.LoggerCore.Formatters.Default
{
    public class LogFormatter : ILogFormatter
    {
        public string FormatException(Exception exception)
        {
            if (exception != null)
                return exception.Message + Environment.NewLine + exception.StackTrace;

            return string.Empty;
        }

        public string FormatMessage(LogLevel level, DateTime time, string message, object source)
        {
            return $"{level.ToString().Substring(0, 3).ToUpper()} {time.ToString("G")} [{(source != null ? source.GetType().Name : "unknown")}]: {message}";
        }
    }
}