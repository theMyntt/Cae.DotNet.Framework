using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode
{
    public class NativeExtractionModeIO
    {
        private NativeExtractionModeIO() { }

        public static string ExecuteOn(object obj)
        {
            return SimpleJsonBuilder.BuildFor(obj);
        }
    }
}
