using System.Windows.Input;
using Windows.UI.Xaml;

namespace MvvmNavigationToolkit.WindowsStore.Sample.Extensions
{
    public class CommonExtensions
    {
        public static ICommand GetTappedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(TappedCommandProperty);
        }

        public static void SetTappedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(TappedCommandProperty, value);
        }

        public static readonly DependencyProperty TappedCommandProperty =
            DependencyProperty.RegisterAttached("TappedCommand", typeof(ICommand), typeof(CommonExtensions), new PropertyMetadata(null, TappedCommandCallback));

        public static object GetTappedCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(TappedCommandParameterProperty);
        }

        public static void SetTappedCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(TappedCommandParameterProperty, value);
        }

        public static readonly DependencyProperty TappedCommandParameterProperty =
            DependencyProperty.RegisterAttached("TappedCommandParameter", typeof(object), typeof(CommonExtensions), new PropertyMetadata(null));

        private static void TappedCommandCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = d as FrameworkElement;
            if (fe != null)
            {
                fe.Tapped += (s, ea) =>
                {
                    var cmd = GetTappedCommand(d);
                    if (cmd != null)
                    {
                        cmd.Execute(GetTappedCommandParameter(d));
                    }
                };
            }
        }



        public static bool GetSwallowTapEvent(DependencyObject obj)
        {
            return (bool)obj.GetValue(SwallowTapEventProperty);
        }

        public static void SetSwallowTapEvent(DependencyObject obj, bool value)
        {
            obj.SetValue(SwallowTapEventProperty, value);
        }

        // Using a DependencyProperty as the backing store for SwallowTapEvent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SwallowTapEventProperty =
            DependencyProperty.RegisterAttached("SwallowTapEvent", typeof(bool), typeof(CommonExtensions), new PropertyMetadata(false));
    }
}
