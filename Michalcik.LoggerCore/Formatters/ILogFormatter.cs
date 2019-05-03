using System;

namespace Michalcik.LoggerCore.Formatters
{
    public interface ILogFormatter
    {
        string FormatException(Exception exception);
        string FormatMessage(LogLevel level, DateTime time, string message, object source);
    }
}