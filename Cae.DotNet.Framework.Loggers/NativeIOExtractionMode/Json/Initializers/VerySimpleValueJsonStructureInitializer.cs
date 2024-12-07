using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Initializers
{
    public class VerySimpleValueJsonStructureInitializer : IJsonStructureInitializer
    {
        private VerySimpleValueJsonStructureInitializer() { }

        public static VerySimpleValueJsonStructureInitializer Singleton { get; } = new VerySimpleValueJsonStructureInitializer();
        public StringBuilder Execute()
        {
            return new StringBuilder("\"");
        }
    }
}
