using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Finalizers
{
    public class VerySimpleValueJsonStructureFinalizer : IJsonStructureFinalizer
    {
        private VerySimpleValueJsonStructureFinalizer() { }
        public static VerySimpleValueJsonStructureFinalizer Singleton { get; } = new VerySimpleValueJsonStructureFinalizer();
        public void Execute(StringBuilder builder)
        {
            builder.Append("\"");
        }
    }
}
