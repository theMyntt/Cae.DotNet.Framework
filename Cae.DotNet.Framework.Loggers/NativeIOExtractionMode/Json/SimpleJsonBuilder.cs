using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Finalizers;
using Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Initializers;
using Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json.Reflections;

namespace Cae.DotNet.Framework.Loggers.NativeIOExtractionMode.Json
{
    public class SimpleJsonBuilder
    {
        private SimpleJsonBuilder(bool isOfCollection, bool isOfVerySimpleValue, IJsonStructureInitializer initializer, IJsonStructureFinalizer finalizer, object levelZero)
        {
            IsOfCollection = isOfCollection;
            IsOfVerySimpleValue = isOfVerySimpleValue;
            Initializer = initializer;
            Finalizer = finalizer;
            LevelZero = levelZero;
            Builder = Initializer.Execute();
        }

        public static readonly int StartingPointForCounter = 1;

        public bool IsOfCollection { get; init; } = false;
        public bool IsOfVerySimpleValue { get; init; } = false;
        public IJsonStructureInitializer Initializer { get; init; }
        public IJsonStructureFinalizer Finalizer { get; init; }
        public StringBuilder Builder { get; init; }
        public object LevelZero { get; init; }

        private static SimpleJsonBuilder OfCollection(object levelZero)
        {
            return new SimpleJsonBuilder(
                true,
                false,
                CollectionJsonStructureInitializer.Singleton,
                CollectionJsonStructureFinalizer.Singleton,
                levelZero);
        }

        private static SimpleJsonBuilder OfCommonObject(object levelZero)
        {
            return new SimpleJsonBuilder(
                false,
                false,
                CommonJsonStructureInitializer.Singleton,
                CommonJsonStructureFinalizer.Singleton,
                levelZero);
        }

        private static SimpleJsonBuilder OfSimpleValue(object simpleValue)
        {
            return new SimpleJsonBuilder(
                false,
                true,
                VerySimpleValueJsonStructureInitializer.Singleton,
                VerySimpleValueJsonStructureFinalizer.Singleton,
                simpleValue);
        }

        public static string BuildFor(object value)
        {
            if (value == null)
            {
                return "null";
            }

            if (ValueTypeScanner.IsSimpleValue(value))
            {
                return nameof(value);
            }

            var builder = value is IEnumerable ? SimpleJsonBuilder.OfCollection(value) : SimpleJsonBuilder.OfCommonObject(value);
            return builder.Build();
        }

        public string Build()
        {
            if (IsOfCollection)
            {
                HandleCollection();
            }
            else if (IsOfVerySimpleValue)
            {
                HandleVerySimpleValue();
            }
            else
            {
                // TODO: Handle common object
            }

            Finalizer.Execute(Builder);
            return Builder.ToString();
        }

        private void Append(object value)
        {
            Builder.Append(value);
        }

        private string GetItemsFromCollection()
        {
            var items = new StringBuilder();
            var couner = 1;
            foreach (var item in (IList)LevelZero)
            {
                items.Append(BuildFor(item));
                if (couner < ((IList)LevelZero).Count)
                {
                    items.Append(", ");
                }
                couner++;
            }
            return items.ToString();
        }

        private void HandleCollection()
        {
            Append(GetItemsFromCollection());
        }

        private void HandleVerySimpleValue()
        {
            Append(LevelZero);
        }
    }
}
