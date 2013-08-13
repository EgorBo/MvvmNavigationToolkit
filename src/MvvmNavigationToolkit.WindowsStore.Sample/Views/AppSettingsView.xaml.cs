using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MvvmNavigationToolkit.WindowsStore.Sample.Views
{
    [PreferredLocationAttribute(ViewPreferredLocationType.SettingsPanel)]
    public sealed partial class AppSettingsView 
    {
        public AppSettingsView()
        {
            this.InitializeComponent();
        }
    }
}
