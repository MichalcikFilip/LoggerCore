using Michalcik.LoggerCore.Formatters;
using Michalcik.LoggerCore.Writers;
using System.Collections.Generic;

namespace Michalcik.LoggerCore.Units
{
    public interface ILogUnitFactory
    {
        ILogUnit Create(ILogFormatter formatter, IEnumerable<ILogWriter> writers);
    }
}