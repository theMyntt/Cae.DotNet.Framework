using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers
{
    public class LoggerProvider
    {
        private LoggerProvider() { }

        public static LoggerProvider Singleton { get; set; } = new LoggerProvider();

        public ILogger? ProvidedInstance { get; set; }
        public bool UseCasesLoggingIO { get; set; } = false;
        public bool PortsLoggingIO { get; set; } = false;
        public IOLoggingModeEnum IOLogginModeEnum { get; set; } = IOLoggingModeEnum.CaeNative;
        public bool Async { get; set; } = false;
        public bool StructuredFormat { get; set; } = false;
        public bool LogStackTrace { get; set; } = false;
        public int LinesOfStackTrace { get; set; } = 5;
    }
}
