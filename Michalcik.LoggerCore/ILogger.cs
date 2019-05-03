using System;

namespace Michalcik.LoggerCore
{
    public interface ILogger
    {
        LogLevel MinLevel { get; set; }

        void Message(LogLevel level, string message, object source);
        void Exception(LogLevel level, Exception exception, object source);
        void Debug(string message, object source);
        void Debug(Exception exception, object source);
        void Info(string message, object source);
        void Info(Exception exception, object source);
        void Warning(string message, object source);
        void Warning(Exception exception, object source);
        void Error(string message, object source);
        void Error(Exception exception, object source);
    }
}