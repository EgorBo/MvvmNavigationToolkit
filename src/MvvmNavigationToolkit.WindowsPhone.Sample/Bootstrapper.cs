using Autofac;
using MvvmNavigationToolkit.WindowsPhone.Sample.Infrastructure;

namespace MvvmNavigationToolkit.WindowsPhone.Sample
{
    public static class Bootstrapper
    {
        private static bool _wasRun;

        public static void Run()
        {
            if (_wasRun)
                return;
            _wasRun = true;

            var builder = new ContainerBuilder();

            var modules = new LayerModule[]
                {
                    new ApplicationModule(),
                };
            foreach (var module in modules)
                builder.RegisterModule(module);

            var container = builder.Build();
            ServiceLocator.Init(container);
            foreach (var module in modules)
                module.OnPostContainerBuild(container);
        }
    }
}