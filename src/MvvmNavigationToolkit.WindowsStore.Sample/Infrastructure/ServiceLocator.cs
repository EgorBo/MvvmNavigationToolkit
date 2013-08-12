using System.Diagnostics;
using System.Linq;
using Autofac;

namespace MvvmNavigationToolkit.WindowsStore.Sample.Infrastructure
{
    public static class ServiceLocator
    {
        public static void Init(IContainer container)
        {
            Instance = container;
        }

        private static IContainer Instance { get; set; }
        
        [DebuggerStepThrough]
        public static T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }

        [DebuggerStepThrough]
        public static T ResolveWith<T>(params object[] parameters) where T : class
        {
            return Instance.ResolveOptional<T>(parameters.Select(i => new TypedParameter(i.GetType(), i)));
        }
    }
}
