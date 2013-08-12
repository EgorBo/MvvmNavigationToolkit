using System.Windows;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.ViewModels
{
    public class FrameViewModel : BaseViewModel
    {
        private bool _isBusy;
        
        public bool IsBusy
        {
            get { return _isBusy; }
            set { Deployment.Current.Dispatcher.BeginInvoke(() => Set("IsBusy", ref _isBusy, value)); }
        }
    }
}
