using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MarketingVillage.Foundation.Common.Helpers
{
    public static class Reflection
    {
        public static class GetAssemblies
        {
            public static Assembly[] GetByFilter(params string[] assemblyFilters)
            {
                var assemblyNames = new HashSet<string>(assemblyFilters.Where(filter => !filter.Contains('*')));
                var wildcardNames = assemblyFilters.Where(filter => filter.Contains('*')).ToArray();

                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly =>
                {
                    var nameToMatch = assembly.GetName().Name;
                    if (assemblyNames.Contains(nameToMatch)) return true;

                    return wildcardNames.Any(wildcard => UtilityBelt.IsWildcardMatch(nameToMatch, wildcard));
                })
                    .ToArray();

                return assemblies;
            }

        }

        public static class GetTypes
        {
            public static Type[] GetTypesImplementing<T>(params Assembly[] assemblies)
            {
                if (assemblies == null || assemblies.Length == 0)
                {
                    return new Type[0];
                }

                var targetType = typeof(T);

                return assemblies
                    .Where(assembly => !assembly.IsDynamic)
                    .SelectMany(GetExportedTypes)
                    .Where(type => !type.IsAbstract && !type.IsGenericTypeDefinition && targetType.IsAssignableFrom(type))
                    .ToArray();
            }

            private static IEnumerable<Type> GetExportedTypes(Assembly assembly)
            {
                try
                {
                    return assembly.GetExportedTypes();
                }
                catch (NotSupportedException)
                {
                    // A type load exception would typically happen on an Anonymously Hosted DynamicMethods
                    // Assembly and it would be safe to skip this exception.
                    return Type.EmptyTypes;
                }
                catch (ReflectionTypeLoadException ex)
                {
                    // Return the types that could be loaded. Types can contain null values.
                    return ex.Types.Where(type => type != null);
                }
                catch (Exception ex)
                {
                    // Throw a more descriptive message containing the name of the assembly.
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                        "Unable to load types from assembly {0}. {1}", assembly.FullName, ex.Message), ex);
                }
            }
        }
    }
}