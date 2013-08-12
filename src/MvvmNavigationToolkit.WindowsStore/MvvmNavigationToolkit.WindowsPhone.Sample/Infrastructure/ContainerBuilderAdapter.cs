using System;
using Autofac;
using MvvmNavigationToolkit.Contracts;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.Infrastructure
{
    /// <summary>
    /// Autofac implementation of IIoCContainerBuilder
    /// </summary>
    public class ContainerBuilderAdapter : IIoCContainerBuilder
    {
        private readonly ContainerBuilder _container;

        public ContainerBuilderAdapter(ContainerBuilder container)
        {
            _container = container;
        }

        public void RegisterAsSingleton(Type timplementation, Type tinterface)
        {
            _container.RegisterType(timplementation).As(tinterface).SingleInstance();
        }

        public void Register(Type timplementation, Type tinterface)
        {
            _container.RegisterType(timplementation).As(tinterface).InstancePerDependency();
        }

        public void RegisterAsSingleton(Type timplementation)
        {
            _container.RegisterType(timplementation).AsSelf().SingleInstance();
        }

        public void Register(Type timplementation)
        {
            _container.RegisterType(timplementation).AsSelf().InstancePerDependency();
        }
    }
}
