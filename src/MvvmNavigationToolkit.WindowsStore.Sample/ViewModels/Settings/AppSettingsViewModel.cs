namespace MvvmNavigationToolkit.WindowsStore.Sample.ViewModels.Settings
{
    public class AppSettingsViewModel : BaseViewModel
    {
        private bool _someBoolean;

        public bool SomeBoolean
        {
            get { return _someBoolean; }
            set { SetProperty(ref _someBoolean, value); }
        }
    }
}
