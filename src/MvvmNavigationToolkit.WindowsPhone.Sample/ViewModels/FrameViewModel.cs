using System.Windows;
using GalaSoft.MvvmLight;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.ViewModels
{
    public class FrameViewModel : ViewModelBase
    {
        private bool _isBusy;
        
        public bool IsBusy
        {
            get { return _isBusy; }
            set { Deployment.Current.Dispatcher.BeginInvoke(() => Set("IsBusy", ref _isBusy, value)); }
        }
    }
}
