using System;

namespace MvvmNavigationToolkit.Contracts
{
    public interface ICloseable
    {
        event EventHandler CloseRequested;
        void OnClose();
    }
}
