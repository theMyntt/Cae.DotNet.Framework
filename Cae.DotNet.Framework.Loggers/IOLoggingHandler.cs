using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cae.DotNet.Framework.Loggers.NativeIOExtractionMode;

namespace Cae.DotNet.Framework.Loggers
{
    public class IOLoggingHandler
    {
        private IOLoggingHandler() { }

        public static string GenerateTextForLoggingInput(object input, string prefix)
        {
            return $"[{prefix} INPUT]: {((LoggerProvider.Singleton.IOLogginModeEnum == IOLoggingModeEnum.CaeNative) ? IOLoggingHandler.HandleNativeExtractionOf(input) : nameof(input))}";
        }

        public static string GenerateTextForLoggingOutput(object output, string prefix)
        {
            return $"[{prefix} OUTPUT]: {((LoggerProvider.Singleton.IOLogginModeEnum == IOLoggingModeEnum.CaeNative) ? IOLoggingHandler.HandleNativeExtractionOf(output) : nameof(output))}";
        }

        private static string HandleNativeExtractionOf(object obj)
        {
            return NativeExtractionModeIO.ExecuteOn(obj);
        }
    }
}
