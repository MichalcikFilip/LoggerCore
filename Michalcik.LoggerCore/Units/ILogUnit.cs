using System;

namespace Michalcik.LoggerCore.Units
{
    public interface ILogUnit
    {
        void LogMessage(LogLevel level, DateTime time, string message, object source);
        void LogException(LogLevel level, DateTime time, Exception exception, object source);
    }
}