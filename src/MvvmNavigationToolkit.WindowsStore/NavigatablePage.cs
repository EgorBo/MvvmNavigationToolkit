using Windows.UI.Xaml.Controls;

namespace MvvmNavigationToolkit
{
    /// <summary>
    /// Base class for page that support mvvm navigation
    /// </summary>
    public class NavigatablePage : Page
    {
        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            var viewModel = ViewModelsRegistry.GetAndDeregister(e.Parameter == null ? "" : e.Parameter.ToString());
            if (viewModel != null)
            {
                this.DataContext = viewModel;
                var navigatable = viewModel as INavigatableViewModel;
                if (navigatable != null)
                {
                    navigatable.OnNavigatedTo();
                }
            }
        }

    }
}
