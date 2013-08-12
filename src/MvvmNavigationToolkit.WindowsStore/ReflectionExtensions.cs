using System;
using System.Linq;
using System.Reflection;

namespace MvvmNavigationToolkit
{
    public static class ReflectionExtensions
    {
        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.GetTypeInfo().CustomAttributes.Any(i => i.AttributeType == attributeType);
        }
    }
}
