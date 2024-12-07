using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Reflections
{
    public class ValueTypeScanner
    {
        public static bool IsSimpleValue(object value)
        {
            var type = value.GetType();

            return (type.IsPrimitive || type.Namespace.StartsWith("System") || type.Namespace.StartsWith("Microsoft")) && !(value is IEnumerable);
        }
    }
}
