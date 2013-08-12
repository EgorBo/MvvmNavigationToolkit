using Microsoft.Phone.Controls;

namespace MvvmNavigationToolkit
{
    /// <summary>
    /// Base class for page that support mvvm navigation
    /// </summary>
    public class NavigatablePage : PhoneApplicationPage
    {
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var viewModel = NavigationManagerBase.GetDataContext(NavigationContext);
            if (viewModel is INavigatableViewModel)
                ((INavigatableViewModel)viewModel).OnNavigatedTo();
            if (viewModel != null)
                DataContext = viewModel;

            base.OnNavigatedTo(e);
        }
    }
}
