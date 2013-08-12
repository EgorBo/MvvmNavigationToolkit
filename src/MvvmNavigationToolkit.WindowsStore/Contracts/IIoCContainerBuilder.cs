using System;

namespace MvvmNavigationToolkit.Contracts
{
    public interface IIoCContainerBuilder
    {
        void RegisterAsSingleton(Type timplementation, Type tinterface);

        void Register(Type timplementation, Type tinterface);

        void RegisterAsSingleton(Type timplementation);

        void Register(Type timplementation);
    }
}
