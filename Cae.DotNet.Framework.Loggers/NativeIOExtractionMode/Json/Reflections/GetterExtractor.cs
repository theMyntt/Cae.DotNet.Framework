using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Reflections
{
    public class GetterExtractor
    {
        private GetterExtractor() { }

        public static IEnumerable<MethodInfo> ExecuteOn(object levelZero)
        {
            var type = levelZero.GetType();
            var methods = type.IsEnum ? type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static) : type.GetMethods();

            return methods
                .Where(m => m.Name.StartsWith("get") && m.Name != "GetType")
                .ToList();
        }
    }
}
