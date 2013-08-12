using System.Threading.Tasks;
using System.Windows.Navigation;
using MvvmNavigationToolkit.WindowsPhone.Sample.Infrastructure;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.Views
{
    public partial class SplashScreenView : NavigatablePage
    {
        public SplashScreenView()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await Task.Delay(1500); //imitates business logic
            ServiceLocator.Resolve<NavigationManagerBase>().StartupNavigation(NavigationContext);
        }
    }
}