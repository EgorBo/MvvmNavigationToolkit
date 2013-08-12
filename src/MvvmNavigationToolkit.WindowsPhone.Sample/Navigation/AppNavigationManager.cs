using System;
using System.Windows.Navigation;
using MvvmNavigationToolkit.WindowsPhone.Sample.Infrastructure;
using MvvmNavigationToolkit.WindowsPhone.Sample.ViewModels;
using MvvmNavigationToolkit.WindowsPhone.Sample.Views;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.Navigation
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

        public override string ViewsFolder
        {
            get { return "/Views"; }
        }

        public override void StartupNavigation(NavigationContext navigationContext)
        {
            //here you can parse arguments or check some logic and run needed page 
            ServiceLocator.Resolve<MainViewModel>().Show();
        }
    }
}
