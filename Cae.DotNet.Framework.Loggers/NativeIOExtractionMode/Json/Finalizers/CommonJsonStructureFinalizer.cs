using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Finalizers
{
    public class CommonJsonStructureFinalizer : IJsonStructureFinalizer
    {
        private CommonJsonStructureFinalizer() { }

        public static CommonJsonStructureFinalizer Singleton { get; } = new CommonJsonStructureFinalizer();

        public void Execute(StringBuilder builder)
        {
            builder.Append(" }");
        }
    }
}
