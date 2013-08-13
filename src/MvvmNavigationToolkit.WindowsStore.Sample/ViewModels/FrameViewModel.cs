using Windows.UI.Core;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;

namespace MvvmNavigationToolkit.WindowsStore.Sample.ViewModels
{
    public class FrameViewModel : ViewModelBase
    {
        private bool _isBusy;
        
        public bool IsBusy
        {
            get { return _isBusy; }
            set { Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, (() => Set("IsBusy", ref _isBusy, value))); }
        }
    }
}
