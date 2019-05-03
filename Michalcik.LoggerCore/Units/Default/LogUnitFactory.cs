using Michalcik.LoggerCore.Formatters;
using Michalcik.LoggerCore.Writers;
using System.Collections.Generic;

namespace Michalcik.LoggerCore.Units.Default
{
    public class LogUnitFactory : ILogUnitFactory
    {
        public ILogUnit Create(ILogFormatter formatter, IEnumerable<ILogWriter> writers)
        {
            if (formatter != null && writers != null)
                return new LogUnit(formatter, writers);

            return null;
        }
    }
}