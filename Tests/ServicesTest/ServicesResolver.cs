using System;
using System.Collections.Generic;
using System.Linq;

namespace Unir.ServicesTest
{
    public static class ServicesResolver
    {
        public static T Resolve<T>(params object[] args)
        {
            var constructor = typeof(T).GetConstructors().OrderByDescending(c => c.GetParameters().Count()).First();
            
            var instances = new List<object>();
            foreach (var param in constructor.GetParameters())
            {
                var instance = args.FirstOrDefault(a => DerivedFromType(a.GetType(), param.ParameterType));
                instances.Add(instance);
            }

            return (T)Activator.CreateInstance(typeof(T), instances.ToArray());
        }

        private static bool DerivedFromType(Type typeToCheck, Type parentType)
        {
            if (typeToCheck == null || typeToCheck == typeof(object)) return false;
            
            if (parentType.IsInterface && typeToCheck.GetInterfaces().Contains(parentType))
                return true;
            
            return typeToCheck == parentType || DerivedFromType(typeToCheck.BaseType ?? typeToCheck.GetInterfaces().FirstOrDefault(), parentType);
        }
    }
}