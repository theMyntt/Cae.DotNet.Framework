using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Finalizers
{
    public interface IJsonStructureFinalizer
    {
        void Execute(StringBuilder builder);
    }
}
