using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cae.DotNet.Framework.MappedExceptions;
using Cae.DotNet.Framework.MappedExceptions.Specifics;

namespace Cae.DotNet.Framework.Loggers
{
    public class StackTraceLogger
    {
        private StackTraceLogger() { }

        public static StackTraceLogger Singleton { get; } = new StackTraceLogger();

        public void HandleLoggingStackTrace(Exception exception, ExecutionContext context, string name)
        {
            if (LoggerProvider.Singleton.LogStackTrace)
            {
                var logger = LoggerProvider.Singleton.ProvidedInstance;
                if (logger == null)
                    throw new InternalMappedException("No logger instance was provided", "Please make sure an instance of Logger is provided", null);

                var mappedException = new MappedException("Stack trace logging", "", exception);
                var linesOfStackTrace = mappedException.GetLinesFromStackTraceFromOriginalException(LoggerProvider.Singleton.LinesOfStackTrace);
                var linesAsUniqueString = linesOfStackTrace.Aggregate(
                    "From execution context of '" + context + "' at '" + name + "'",
                    (previous, next) => previous + "\n\t\t" + next); ;

                logger.LogError(linesAsUniqueString);
            }
        }
    }
}
