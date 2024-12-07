using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cae.DotNet.Framework.MappedExceptions.Specifics;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Reflections
{
    public class FieldRetriever
    {
        private FieldRetriever() { }
        
        public static FieldInfo? GetField(string fieldName, object obj)
        {
            var classWhereFieldIsDeclared = FindRightClassFrom(obj.GetType(), fieldName);
            return classWhereFieldIsDeclared != null ? RetrieveField(classWhereFieldIsDeclared, fieldName) : null;
        }

        private static Type? FindRightClassFrom(Type? clazz, string fieldName)
        {
            if (clazz == typeof(object) || clazz == null)
                return null;

            var field = clazz.GetFields();

            if (field.Any(f => f.Name == fieldName))
                return clazz;

            return FindRightClassFrom(clazz.BaseType, fieldName);
        }

        private static FieldInfo? RetrieveField(Type? foundClass, string fieldName)
        {
            try
            {
                return foundClass?.GetField(fieldName);
            }
            catch (Exception e)
            {
                throw new InternalMappedException(
                    "Something went wrong while trying to retrieve the field '" + fieldName + "' in '" + foundClass.Name + "'",
                    "We found the class in which the field should be located, but at the retrievement attempt something went unexpectedly wrong. See the exception: " + e,
                    null);
            }
        }
    }
}
