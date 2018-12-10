using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ParcelDelivery.Common
{
    public static class ObjectProvider
    {
        public static IEnumerable<T> GetAllTypesOf<T>()
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
            var type = typeof(T);
            var assemblies = runtimeAssemblyNames
                .Select(Assembly.Load).SelectMany(s=> s.ExportedTypes)
                .Where(t => type.IsAssignableFrom(t) && t.Name != type.Name).Select(a=>(T)a.Assembly.CreateInstance(a.FullName));
            return assemblies;
        }
    }
}