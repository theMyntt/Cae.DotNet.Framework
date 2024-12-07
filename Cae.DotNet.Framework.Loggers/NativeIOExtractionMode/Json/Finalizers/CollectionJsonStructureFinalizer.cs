using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Finalizers
{
    public class CollectionJsonStructureFinalizer : IJsonStructureFinalizer
    {
        private CollectionJsonStructureFinalizer() { }

        public static CollectionJsonStructureFinalizer Singleton { get; } = new CollectionJsonStructureFinalizer();

        public void Execute(StringBuilder builder)
        {
            builder.Append(" ]");
        }
    }
}
