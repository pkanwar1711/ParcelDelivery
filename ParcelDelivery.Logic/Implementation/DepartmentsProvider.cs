using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using ParcelDelivery.Dto;
using ParcelDelivery.Logic.Contract;

namespace ParcelDelivery.Logic.Implementation
{
    public class DepartmentsProvider
    {
       
        
        public IDepartments Departments(Parcel parcel)
        {

            var department = GetAllTypesOf<IDepartments>();
            if (!department.Any())
            {
                throw new Exception("Department not found");
            }

            return null;

        }


        //private static IEnumerable<T> GetAllTypesOf<T>()
        //{
        //    var assembly = Assembly.GetEntryAssembly();
        //    var assemblies = assembly.GetReferencedAssemblies();
        //    var obj = new List<T>();
        //    foreach (var assemblyName in assemblies)
        //    {
        //        assembly = Assembly.Load(assemblyName);

        //        foreach (var ti in assembly.DefinedTypes)
        //        {
        //            if (ti.ImplementedInterfaces.Contains(typeof(T)))
        //            {
        //                obj.Add((T)assembly.CreateInstance(ti.FullName));
        //            }
        //        }
        //    }

        //    return obj;
        //}

        private static IEnumerable<Type> GetAllTypesOf<T>()
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            return runtimeAssemblyNames
                .Select(Assembly.Load)
                .SelectMany(a => a.ExportedTypes)
                .Where(t => typeof(T).IsAssignableFrom(t));
        }
    }


}