using Michalcik.LoggerCore.Formatters;
using Michalcik.LoggerCore.Units;
using Michalcik.LoggerCore.Units.Default;
using Michalcik.LoggerCore.Writers;
using System;
using System.Collections.Generic;

namespace Michalcik.LoggerCore
{
    public class LoggerBase : ILogger
    {
        private ILogUnitFactory unitFactory;
        private List<ILogUnit> units = new List<ILogUnit>();

        public LogLevel MinLevel { get; set; }

        public LoggerBase(LogLevel minLevel)
            : this(minLevel, new LogUnitFactory())
        { }

        public LoggerBase(LogLevel minLevel, ILogUnitFactory unitFactory)
        {
            MinLevel = minLevel;

            this.unitFactory = unitFactory ?? throw new ArgumentNullException(nameof(unitFactory));
        }

        public void AddConfiguration(ILogFormatter formatter, IEnumerable<ILogWriter> writers)
        {
            ILogUnit unit = unitFactory.Create(formatter, writers);

            if (unit != null)
                units.Add(unit);
        }

        protected virtual bool CanLogMessage(LogLevel level, object source)
        {
            return level >= MinLevel;
        }

        public void Message(LogLevel level, string message, object source)
        {
            DateTime time = DateTime.Now;

            if (CanLogMessage(level, source))
                foreach (ILogUnit unit in units)
                    unit.LogMessage(level, time, message, source);
        }

        public void Exception(LogLevel level, Exception exception, object source)
        {
            DateTime time = DateTime.Now;

            if (CanLogMessage(level, source))
                foreach (ILogUnit unit in units)
                    unit.LogException(level, time, exception, source);
        }

        public void Debug(string message, object source)
        {
            Message(LogLevel.Debug, message, source);
        }

        public void Debug(Exception exception, object source)
        {
            Exception(LogLevel.Debug, exception, source);
        }

        public void Info(string message, object source)
        {
            Message(LogLevel.Info, message, source);
        }

        public void Info(Exception exception, object source)
        {
            Exception(LogLevel.Info, exception, source);
        }

        public void Warning(string message, object source)
        {
            Message(LogLevel.Warning, message, source);
        }

        public void Warning(Exception exception, object source)
        {
            Exception(LogLevel.Warning, exception, source);
        }

        public void Error(string message, object source)
        {
            Message(LogLevel.Error, message, source);
        }

        public void Error(Exception exception, object source)
        {
            Exception(LogLevel.Error, exception, source);
        }
    }
}