namespace MvvmNavigationToolkit
{
    /// <summary>
    /// Make sure that your viewmodel base class implements this interface in order to handle OnNavigatedTo event
    /// </summary>
    public interface INavigatableViewModel
    {
        void OnNavigatedTo();
    }
}
