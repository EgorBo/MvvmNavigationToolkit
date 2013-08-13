using System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using MvvmNavigationToolkit.WindowsStore.Sample.Infrastructure;

namespace MvvmNavigationToolkit.WindowsStore.Sample.ViewModels.Settings
{
    public class SettingsController
    {
        public static void RegisterSettings(Action<SettingsCommand> registrator)
        {
            int id = 0;
            var settings = new[]
                       {
                           new SettingsCommand(++id, "App options", ShowView<AppSettingsViewModel>()),
                       };

            foreach (var setting in settings)
            {
                registrator(setting);
            }
        }

        private static UICommandInvokedHandler ShowView<T>() where T : BaseViewModel
        {
            return r => ServiceLocator.Resolve<T>().Show();
        }
    }
}
