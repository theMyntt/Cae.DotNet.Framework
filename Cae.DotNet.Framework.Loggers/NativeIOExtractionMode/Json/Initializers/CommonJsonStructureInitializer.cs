using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Initializers
{
    public class CommonJsonStructureInitializer : IJsonStructureInitializer
    {
        private CommonJsonStructureInitializer() { }

        public static CommonJsonStructureInitializer Singleton { get; } = new CommonJsonStructureInitializer();

        public StringBuilder Execute()
        {
            return new StringBuilder("{ ");
        }
    }
}
