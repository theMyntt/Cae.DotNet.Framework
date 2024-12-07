using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Initializers
{
    public class CollectionJsonStructureInitializer : IJsonStructureInitializer
    {
        private CollectionJsonStructureInitializer() { }

        public static CollectionJsonStructureInitializer Singleton { get; } = new CollectionJsonStructureInitializer();

        public StringBuilder Execute()
        {
            return new StringBuilder("[ ");
        }
    }
}
