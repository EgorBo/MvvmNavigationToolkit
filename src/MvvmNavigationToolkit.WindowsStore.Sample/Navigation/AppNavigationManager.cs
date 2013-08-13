using System;
using Windows.UI.Xaml.Controls;
using MvvmNavigationToolkit.WindowsStore.Sample.Infrastructure;
using MvvmNavigationToolkit.WindowsStore.Sample.ViewModels;
using MvvmNavigationToolkit.WindowsStore.Sample.Views;

namespace MvvmNavigationToolkit.WindowsStore.Sample.Navigation
{
    internal class AppNavigationManager : NavigationManagerBase
    {
        public AppNavigationManager(NavigationBuilder navigationBuilder) 
            : base(navigationBuilder)
        {
        }

        //Navigation on these page will clean navigation stack 
        public override Type[] RootViews
        {
            get
            {
                return new[]
                    {
                        typeof (MainPage),
                    };
            }
        }

        public override void StartupNavigation(Frame rootFrame, string arguments)
        {
            ServiceLocator.Resolve<MainViewModel>().Show();
        }
    }
}
