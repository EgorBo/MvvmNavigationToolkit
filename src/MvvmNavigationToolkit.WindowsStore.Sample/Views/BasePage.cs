using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Navigation;
using MvvmNavigationToolkit.WindowsStore.Sample.ViewModels.Settings;

namespace MvvmNavigationToolkit.WindowsStore.Sample.Views
{
    public class BasePage : NavigatablePage
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += CommandsRequested;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SettingsPane.GetForCurrentView().CommandsRequested -= CommandsRequested;
            base.OnNavigatedFrom(e);
        }

        private void CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Clear();
            SettingsController.RegisterSettings(item => args.Request.ApplicationCommands.Add(item));
        }
    }
}
